// ImageCompressor v0.2.1 update 260508
// https://github.com/Noksek2/ImageCompressor
// MIT License (I don't care License but)


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
namespace ImageCompressor
{
    public partial class ImageCompressor : Form
    {
        enum ComboFormatType : int
        {
            ToPng = 0,
            ToJpg = 1,
            ToBmp = 2,
            ToWebp = 3,
        }
        bool comboCheck;
        string[] formatStrings = { ".png", ".jpeg", ".bmp", ".webp", ".webp", ".jpg" };
        //Dictionary<string>formatDict=
        List<Control> actControls;

        public ImageCompressor()
        {
            InitializeComponent();
            button1.Enabled = false;
            buttonPath.Enabled = false;
            textBoxPath.Enabled = false;
            checkBoxFolder.Checked = true;

            radioSize.Checked = false;
            numericHeight.Enabled = numericWidth.Enabled = false;

            actControls = new List<Control>();

            actControls.Add(groupBox1);
            actControls.Add(groupBox2);
            actControls.Add(groupBox3);
            actControls.Add(groupBox4);
            actControls.Add(button2);
            actControls.Add(button3);

        }

        void GetFilenameAndPath(out string orgpath, out string newpath, out string filename, string file)
        {

            int pidx = 0;
            for (int i = file.Length - 1; i >= 0; i--)
            {
                if (file[i] == '\\') { pidx = i + 1; break; }
            }

            orgpath = file.Substring(0, pidx);
            if (buttonSaveMode.Text == "Auto")
                newpath = orgpath;
            else newpath = textBoxPath.Text;
            if (checkBoxFolder.Checked)
                newpath += textBox_outputfolder.Text + "\\";
            filename = file.Substring(pidx);
        }
        //orgfile -> filename.ext
        void GetFilenameExceptFormat(out string filename, out string ext, string orgfile)
        {
            int idx = 0;
            for (int i = orgfile.Length - 1; i >= 0; i--)
            {
                if (orgfile[i] == '.') { idx = i; break; }
            }
            filename = orgfile.Substring(0, idx);
            ext = orgfile.Substring(idx);
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        //SwapRGBChannel For WEBP (ARGB <-> RGBA)
        void SwapRGBChannel(Bitmap bmp)
        {
            // 픽셀 포맷 확인 (주로 24bppRgb, 32bppArgb에서 발생)
            if (bmp.PixelFormat != PixelFormat.Format24bppRgb &&
                bmp.PixelFormat != PixelFormat.Format32bppArgb)
            {
                // 다른 포맷은 일단 보류 (혹은 예외 처리)
                // 8bpp Indexed 등은 팔레트를 수정해야 함
                return;
            }

            int bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            if (bytesPerPixel < 3) return; // 24비트 미만은 R,G,B가 다 없음

            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);

            IntPtr ptr = bmpData.Scan0;
            int byteCount = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] pixels = new byte[byteCount];
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, byteCount);

            // 픽셀 순회 (B-G-R -> R-G-B)
            for (int i = 0; i < byteCount; i += bytesPerPixel)
            {
                byte temp = pixels[i];     // Blue
                pixels[i] = pixels[i + 2]; // Red
                pixels[i + 2] = temp;      // Blue
                                           // (i + 1)은 Green이므로 건드리지 않음
                                           // (i + 3)은 Alpha이므로 건드리지 않음
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, byteCount);
            bmp.UnlockBits(bmpData);
        }
        RotateFlipType GetBitmapRotateFlipType(int idx)
        {
            int[] map ={
				// 0,4,6,
				(int)RotateFlipType.RotateNoneFlipNone,
                (int)RotateFlipType.RotateNoneFlipX,
                (int)RotateFlipType.RotateNoneFlipY,
				
				//2,6,4,
				(int)RotateFlipType.Rotate180FlipNone,
                (int)RotateFlipType.RotateNoneFlipX,
                (int)RotateFlipType.Rotate180FlipX,
				
                //1,5,7,
				(int)RotateFlipType.Rotate90FlipNone,
                (int)RotateFlipType.Rotate90FlipX,
                (int)RotateFlipType.Rotate270FlipX,

                //3,7,5
				(int)RotateFlipType.Rotate270FlipNone,
                (int)RotateFlipType.Rotate270FlipX,
                (int)RotateFlipType.Rotate90FlipX,
            };
            return (RotateFlipType)map[comboRotation.SelectedIndex * 3 + comboFlip.SelectedIndex];
        }
        Bitmap CreateLetterBoxBitmap(Bitmap srcBmp, int resW, int resH, Color bgColor)
        {
            Bitmap resBmp = new Bitmap(resW, resH, srcBmp.PixelFormat);
            using (Graphics g = Graphics.FromImage(resBmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.Clear(bgColor);


                
                float ratioX = (float)resW / srcBmp.Width;
                float ratioY = (float)resH / srcBmp.Height;
                
                float ratio = Math.Min(ratioX, ratioY);

                // 5. 새 크기 계산
                int newW = (int)(srcBmp.Width * ratio);
                int newH = (int)(srcBmp.Height * ratio);

                // 6. 중앙 배치를 위한 시작 좌표(X, Y) 계산
                int posX = (resW - newW) / 2;
                int posY = (resH - newH) / 2;

                // 7. 여백이 있는 도화지 중앙에 원본 이미지 그리기
                g.DrawImage(srcBmp, posX, posY, newW, newH);
            }
            return resBmp;
        }

        void ConvertImageQuality(string path, string newfile, string orgext)
        {

            int width = 0, height = 0;
            Bitmap bmp;
            string convext = formatStrings[comboBox1.SelectedIndex];

            var info = GetEncoderInfo("image/" + convext.Substring(1));

            var encodeParas = new EncoderParameters(1);
            var encode = System.Drawing.Imaging.Encoder.Quality;
            var para = new EncoderParameter(encode, (long)numericScroll.Value);
            encodeParas.Param[0] = para;

            //IF FILE IS WEBP
            if (String.Compare(orgext, ".webp") == 0)
            {
                bmp = WebP.DecodeWebPToBitmap(path);
                SwapRGBChannel(bmp);
                if (radioRatio.Checked)
                {
                    width = (int)(numericRatioW.Value * (decimal)bmp.Width / (decimal)100.0);
                    height = (int)(numericRatioH.Value * (decimal)bmp.Height / (decimal)100.0);

                }
                else
                {
                    width = (int)numericWidth.Value;
                    height = (int)numericHeight.Value;
                }
                if (comboStretch.SelectedIndex == 0) {
                    Bitmap letterbox = CreateLetterBoxBitmap(bmp, width, height, buttonBg.BackColor);
                    bmp.Dispose();
                    bmp = letterbox;
                }
                else {
                    bmp = WebP.ResizeBitmap(bmp, width, height);
                }
            }
            //IF FILE IS NOT WEBP
            else
            {
                //x/y res: src = 0.1 : 0.3 = 1/10 : 3/10 -> x에 맞추자.
                // 0.3 : 0.1 -> y에 맞추자. 
                using (Image img = Image.FromFile(path))
                {
                    if (radioRatio.Checked)
                    {
                        width = (int)(numericRatioW.Value * (decimal)img.Width / (decimal)100.0);
                        height = (int)(numericRatioH.Value * (decimal)img.Height / (decimal)100.0);
                    }
                    else
                    {
                        width = (int)numericWidth.Value;
                        height = (int)numericHeight.Value;
                    }

                    var originalFormat = img.PixelFormat;
                    var targetFormat = (originalFormat == PixelFormat.Format32bppArgb ||
                                        originalFormat == PixelFormat.Format64bppArgb ||
                                        originalFormat == PixelFormat.Format32bppPArgb)
                        ? PixelFormat.Format32bppArgb
                        : PixelFormat.Format24bppRgb;

                    if (comboStretch.SelectedIndex == 0)
                    {
                        using (Bitmap tbmp = new Bitmap(img))
                        {
                            bmp = CreateLetterBoxBitmap(tbmp, width, height, buttonBg.BackColor);
                        }
                    }
                    else
                    {
                        bmp = new Bitmap(img, new Size(width, height));
                    }
                    
                    /*using (var g = Graphics.FromImage(bmp))
					{
						g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
						g.DrawImage(img, 0, 0, width, height); // 리사이징하여 그리기
					}*/
                    // --- 수정 끝 ---
                }
            }
            bmp.RotateFlip(GetBitmapRotateFlipType(comboRotation.SelectedIndex));


            if (checkBoxDelorg.Checked) // del 체크 -> 지움
            {
                System.IO.File.Delete(path);
            }
            if (String.Compare(convext, ".webp") == 0)
            {
                WebP.SaveLossy(bmp, newfile, (int)numericScroll.Value);
            }
            else if (String.Compare(convext, ".jpg") == 0 || String.Compare(convext, ".jpg") == 0)
            {
                WebP.SaveLossy(bmp, newfile, (int)numericScroll.Value);
            }
            else bmp.Save(newfile, info, encodeParas);
            bmp.Dispose();
        }
        void GetNewFileName(string file, out string orgpath, out string newpath, out string newfile, out string ext)
        {
            string orgfile, filename;
            GetFilenameAndPath(out orgpath, out newpath, out orgfile, file);
            GetFilenameExceptFormat(out filename, out ext, orgfile);
            newfile = filename;
            if (checkBox_suffix.Checked)
                newfile += textBox_suffix.Text;
            newfile += formatStrings[comboBox1.SelectedIndex];
        }

        bool IsAllowToConvert()
        {
            //1. Check if Button1=ConvertButton is Enabled
            //2. Auto Mode -> Path text != null
            //3. output textBox should be [a-zA-Z0-9]+

            if (!button1.Enabled) return false;

            if (buttonSaveMode.Text != "Auto")
                if (textBoxPath.Text == "")
                {
                    textBox1.Text = "Set the path to save the images\r\n"; return false;
                }
            if (checkBoxFolder.Checked)
            {
                if (!Regex.IsMatch(textBox_outputfolder.Text, @"[_a-zA-Z0-9]+$"))
                {
                    textBox1.Text = $"Invalid output folder name:\"{textBox_outputfolder.Text}\" Pattern : [_a-zA-Z0-9]+\r\n"; return false;
                }
            }
            return true;
        }
        bool OpenImagesFromDialog(out string[] fileNames)
        {
            fileNames = null;
            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "All Image Files(*.jpg,*.jpeg,*.bmp,*.png,*.webp)" +
                "|*.jpg;*.jpeg;*.png;*.bmp;*.webp|jpg files(*.jpg, *.jpeg)|*.jpg;*.jpeg" +
                "|png files(*.png)|*.png|bmp files(*.bmp)|*.bmp" +
                "|webp files(*.webp)|*.webp";
            if (dlg.ShowDialog() != DialogResult.OK)
                return false;

            fileNames = dlg.FileNames;
            return true;
        }
        bool CheckImgFormat(string ext)
        {
            foreach (var fmt in formatStrings)
            {
                if (String.Compare(ext, fmt) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        void AppendTextMsg(string s)
        {
            Action e = () =>
            {
                textBox1.AppendText(s);
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            };
            if (textBox1.InvokeRequired)
                textBox1.Invoke(new MethodInvoker(e));
            else e();

        }
        void ConvertImages(string[] fileNames, bool isDrop = false) //변환할 파일들, Drop 여부
        {
            EnableControls(false); //컨트롤 비활성화 (변환 오류 방지)
            string orgpath, newpath, newfile, ext; //원본 파일 경로, 새 파일 경로, 확장자
            int suc = 0, fai = 0; //성공 횟수, 실패 횟수

            if (buttonSaveMode.Text != "Auto")
                AppendTextMsg("Located in \"" + textBoxPath.Text + "\"\r\n");

            foreach (var file_ in fileNames)
            {
                string file = file_.ToLower();
                GetNewFileName(file, out orgpath, out newpath, out newfile, out ext);
                if (isDrop)
                {
                    if (!CheckImgFormat(ext))
                    {
                        AppendTextMsg("!! File not supported \"" + file + "\"!!\r\n");
                        fai++;
                        continue;
                    }
                }

                if (Directory.Exists(newpath) == false)
                {
                    try { Directory.CreateDirectory(newpath); }
                    catch (Exception ex)
                    {
                        AppendTextMsg($"!!Failed to create directory!! \"{newpath}\" \r\n");
                        fai++;
                        continue;
                    }
                }
                else if (checkBoxOverwrite.Checked == false)
                {
                    if (System.IO.File.Exists(newpath + newfile))
                    {
                        AppendTextMsg($"The file name is duplicated!! \"{newfile}\"\r\n");
                        fai++;
                        continue;
                    }
                }
                if (radioMsgshow.Checked) AppendTextMsg("[" + (suc + fai + 1) + "] Saving \"" + newfile + "\"...\r\n");
                try
                {
                    ConvertImageQuality(file, newpath + newfile, ext);
                    //img.Save(path + newfile,System.Drawing.Imaging.ImageFormat.Jpeg);
                    suc += 1;
                }
                catch (Exception ex)
                {
                    //label1.Text += "!! Failed to open \"" + file + "\"!!\n";
                    if (radioMsgshow.Checked || radioMsgerror.Checked)
                        AppendTextMsg("!! Failed to save \"" + newfile + "\"!!\r\n"+"Msg : "+ex.Message + "\r\n");
                    fai += 1;
                }

            }
            AppendTextMsg("=======Success:" + suc + ", Failed:" + fai + "=======\r\n\r\n");
            EnableControls(true); //컨트롤 활성화 (변환 이전으로 되돌림)
        }

        void EnableControls(bool flag = true) //컨트롤 활성화 여부 (flag)
        {
            for (int i = 0; i < actControls.Count; i++)
            {
                actControls[i].Enabled = flag;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            button1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var newform = new Form2();
            newform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var folddlg = new FolderBrowserDialog();
            if (folddlg.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folddlg.SelectedPath;
                var c = textBoxPath.Text[textBoxPath.Text.Length - 1];
                if (c != '\\' || c != '/') textBoxPath.Text += '\\';
            }
        }

        private void buttonSaveMode_Click(object sender, EventArgs e)
        {
            if (buttonSaveMode.Text == "Auto") buttonSaveMode.Text = "Setup";
            else buttonSaveMode.Text = "Auto";

            if (buttonSaveMode.Text == "Auto")
            {
                buttonPath.Enabled = false;
                textBoxPath.Enabled = false;
                //checkBoxFolder.Checked = true;
                //checkBoxFolder.Enabled = false;
            }
            else
            {
                buttonPath.Enabled = true;
                textBoxPath.Enabled = true;
                //checkBoxFolder.Checked = true;
                //checkBoxFolder.Enabled = true;
            }
        }

        private void ImageConvert_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ?
                DragDropEffects.All : DragDropEffects.None;
        }

        private void ConvertImagesAsync(string[] files, bool isDrop = true)
        {
            Task.Run(
                    () =>
                    {
                        try
                        {
                            ConvertImages(files, isDrop);
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(
                                (MethodInvoker)(() => { ConvertImages(files, isDrop); })
                            );
                        }
                    }
                );
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsAllowToConvert())
            {
                string[] fileNames;
                if (!OpenImagesFromDialog(out fileNames)) return;
                ConvertImagesAsync(fileNames);
            }
        }
        private void ImageConvert_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (IsAllowToConvert())
            {
                //ConvertImages(files, true);
                ConvertImagesAsync(files, true);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ImageConvert_Load(object sender, EventArgs e)
        {
            comboStretch.SelectedIndex = 0;
            comboRotation.SelectedIndex = 0;
            comboFlip.SelectedIndex = 0;
            buttonBg.BackColor = Color.White;
        }

        private void radioRatio_CheckedChanged(object sender, EventArgs e)
        {
            numericHeight.Enabled = numericWidth.Enabled = false;
            numericRatioW.Enabled = numericRatioH.Enabled = true;
        }

        private void radioSize_CheckedChanged(object sender, EventArgs e)
        {
            numericHeight.Enabled = numericWidth.Enabled = true;
            numericRatioW.Enabled = numericRatioH.Enabled = false;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void numericScroll_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!('A' <= e.KeyChar && e.KeyChar <= 'Z') && !('a' <= e.KeyChar && e.KeyChar <= 'z')
                && !('0' <= e.KeyChar && e.KeyChar <= '9') && e.KeyChar != 8 && e.KeyChar != '_'
                ) e.Handled = true;
        }

        private void checkBoxFolder_CheckedChanged(object sender, EventArgs e)
        {
            textBox_outputfolder.Enabled = checkBoxFolder.Checked;
        }

        private void checkBoxDelorg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDelorg.Checked)
                if (MessageBox.Show("Warning! Your files will be erased. Is it okay?", "Caution", MessageBoxButtons.YesNo)
                    == DialogResult.No)
                    checkBoxDelorg.Checked = false;
        }

        private void checkBox_suffix_CheckedChanged(object sender, EventArgs e)
        {
            textBox_suffix.Enabled = checkBox_suffix.Checked;
        }

        private void checkBoxOverwrite_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonBg.BackColor = colorDialog1.Color;
            }
        }
    }
}
