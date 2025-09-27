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
			//formatDict[".png"]
			//formatDict[".jpeg"]
			//formatDict[".jpg"]
			//formatDict[".webp"]
			//formatDict[".bmp"]
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

		void GetFilenameAndPath(out string path, out string filename, string file)
		{

			int pidx = 0;
			for (int i = file.Length - 1; i >= 0; i--)
			{
				if (file[i] == '\\') { pidx = i + 1; break; }
			}


			if (buttonSaveMode.Text == "Auto")
				path = file.Substring(0, pidx);
			else path = textBoxPath.Text;
			if (checkBoxFolder.Checked)
				path += "res\\";
			filename = file.Substring(pidx);
		}
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
		void ImageQuality(string path, string newfile, string orgext)
		{
			//원본 이미지 경로와 겹치는지 확인
			if (checkBoxDelorg.Checked == false)
				//old path=new path, 원본 남길 경우
				if (String.Compare(newfile.ToLower(), path.ToLower()) == 0)
					throw new IOException();

			int width = 0, height = 0;
			Bitmap bmp;
			string convext = formatStrings[comboBox1.SelectedIndex];

			var info = GetEncoderInfo("image/" + convext.Substring(1));

			var encodeParas = new EncoderParameters(1);
			var encode = System.Drawing.Imaging.Encoder.Quality;
			var para = new EncoderParameter(encode, (long)numericScroll.Value);
			encodeParas.Param[0] = para;


			if (String.Compare(orgext, ".webp") != 0)
			{
				using (Image img = Image.FromFile(path))
				{
					if (radioRatio.Checked)
					{
						width = (int)(numericRatio.Value * (decimal)img.Width / (decimal)100.0);
						height = (int)(numericRatio.Value * (decimal)img.Height / (decimal)100.0);
					}
					else
					{
						width = (int)numericWidth.Value;
						height = (int)numericHeight.Value;
					}

					bmp = new Bitmap(img, new Size(width, height));
				}
			}
			else
			{
				bmp = WebP.DecodeWebPToBitmap(path);
				if (radioRatio.Checked)
				{
					width = (int)(numericRatio.Value * (decimal)bmp.Width / (decimal)100.0);
					height = (int)(numericRatio.Value * (decimal)bmp.Height / (decimal)100.0);
				}
				else
				{
					width = (int)numericWidth.Value;
					height = (int)numericHeight.Value;
				}
				bmp = WebP.ResizeBitmap(bmp, width, height);
			}
			int[] map ={0,4,6,
				1,5,7,
				2,6,4,
				3,7,5
			};
			bmp.RotateFlip((RotateFlipType)map[comboRotation.SelectedIndex * 3 + comboFlip.SelectedIndex]);

			if (checkBoxDelorg.Checked) // del 체크 -> 지움
			{
				System.IO.File.Delete(path);
			}
			if (String.Compare(convext, ".webp") == 0)
			{
				WebP.SaveLossy(bmp, newfile, (int)numericScroll.Value);
			}
			else bmp.Save(newfile, info, encodeParas);
			bmp.Dispose();
		}
		void CreateNewFileName(string file, out string path, out string newfile, out string ext)
		{
			string orgfile, filename;
			GetFilenameAndPath(out path, out orgfile, file);
			GetFilenameExceptFormat(out filename, out ext, orgfile);
			newfile = filename + formatStrings[comboBox1.SelectedIndex];
		}
		bool IsAllowToConvert()
		{
			if (!button1.Enabled) return false;
			if (buttonSaveMode.Text != "Auto")
				if (textBoxPath.Text == "")
				{
					textBox1.Text = "Set the path to save the images\r\n"; return false;
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
				textBox1.SelectionStart=textBox1.Text.Length;
				textBox1.ScrollToCaret();
			};
			if(textBox1.InvokeRequired)
				textBox1.Invoke(new MethodInvoker(e));
			else e();
			
		}
		void ConvertImages(string[] fileNames, bool isDrop = false) //변환할 파일들, Drop 여부
		{
			EnableControls(false); //컨트롤 비활성화 (변환 오류 방지)
			string path, newfile, ext; //원본 파일 경로, 새 파일 경로, 확장자
			int suc = 0, fai = 0; //성공 횟수, 실패 횟수
			if (buttonSaveMode.Text == "")
				AppendTextMsg("Located in \"" + textBoxPath.Text + "\"\r\n");

			foreach (var file_ in fileNames)
			{
				string file = file_.ToLower();
				CreateNewFileName(file, out path, out newfile, out ext);
				if (isDrop)
				{
					if (!CheckImgFormat(ext))
					{
						AppendTextMsg("!! File not supported \"" + file + "\"!!\r\n");
						fai++;
						continue;
					}
				}
				if (Directory.Exists(path) == false)
				{
					try { Directory.CreateDirectory(path); }
					catch (Exception ex)
					{
						MessageBox.Show("!!Failed to create directory!!");
						return;
					}
				}
				if (radioMsgshow.Checked) AppendTextMsg("[" + (suc + fai + 1) + "] Saving \"" + newfile + "\"...\r\n");
				try
				{
					ImageQuality(file, path + newfile, ext);
					//img.Save(path + newfile,System.Drawing.Imaging.ImageFormat.Jpeg);
					suc += 1;
				}
				catch (IOException iex)
				{
					AppendTextMsg("!! Converter cannot delete the origin file. \"" + newfile + "\"!!\r\n");
					fai += 1;
				}
				catch (Exception ex)
				{
					//label1.Text += "!! Failed to open \"" + file + "\"!!\n";
					if (radioMsgshow.Checked || radioMsgerror.Checked)
						AppendTextMsg("!! Failed to save \"" + newfile + "\"!!\r\n");
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

		private void labelpath_Click(object sender, EventArgs e)
		{

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

		private void button6_Click(object sender, EventArgs e)
		{

		}

		private void buttonSaveMode_Click(object sender, EventArgs e)
		{
			if (buttonSaveMode.Text == "Auto") buttonSaveMode.Text = "User Mode";
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
			comboRotation.SelectedIndex = 0;
			comboFlip.SelectedIndex = 0;
		}

		private void radioRatio_CheckedChanged(object sender, EventArgs e)
		{
			numericHeight.Enabled = numericWidth.Enabled = false;
			numericRatio.Enabled = true;
		}

		private void radioSize_CheckedChanged(object sender, EventArgs e)
		{
			numericHeight.Enabled = numericWidth.Enabled = true;
			numericRatio.Enabled = false;
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
		}
	}
}
