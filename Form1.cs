using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int currentIndex;
        public Form1()
        {
            InitializeComponent();

            currentIndex = 0;

            SetWifiListView();


            TaskDelay(10000);

        }

        private async void TaskDelay(int msec)
        {
            await Task.Delay(msec);

            currentIndex = wifilistView.FirstDisplayedScrollingRowIndex;

            Debug.WriteLine("10000" + " " + currentIndex);

            await Task.Delay(msec);

            wifilistView.FirstDisplayedScrollingRowIndex = currentIndex;

            Debug.WriteLine("10000");
        }

        public void SetWifiListView()
        {
            wifilistView.Dock = DockStyle.Fill;
            this.Controls.Add(wifilistView); // コントロールをフォームに貼り付け

            this.Load += new EventHandler(DataGridViewRowPainting_Load);
        }

        void DataGridViewRowPainting_Load(object sender, EventArgs e)
        {
            //パディング設定
            Padding newPadding = new Padding(10, 10, 10, 10);
            wifilistView.RowTemplate.DefaultCellStyle.Padding = newPadding;

            //選択時の背景色の設定
            // wifilistView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;// 透明

            //行の高さの設定
            wifilistView.RowTemplate.Height += 20;

            //wifilistView.Enabled = true;

            //行の追加オプションがユーザーに表示される場合は true。それ以外の場合は false
            wifilistView.AllowUserToAddRows = false;
            //セルの編集を開始する方法を示す値を取得または設定
            //モードの内容は、以下のサイトを参照
            // https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.forms.datagridvieweditmode?view=windowsdesktop-6.0#system-windows-forms-datagridvieweditmode-editonkeystrokeorf2
            wifilistView.EditMode = DataGridViewEditMode.EditProgrammatically;

            //セルの境界線スタイル
            wifilistView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            wifilistView.GridColor = Color.LightGray;

            //セルを選択できるかどうかを示す値を取得または設定
            wifilistView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;


            //
            wifilistView.ColumnCount = 3;
            //ヘッダーを非表示
            wifilistView.ColumnHeadersVisible = false;
            wifilistView.RowHeadersVisible = false;

            //背景色
            wifilistView.BackgroundColor = Color.Black;

            //セル内で改行する
            wifilistView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            wifilistView.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //ココをWifiリストで繰り返す。
            string[] row1 = new string[] { "BSSID: " + Environment.NewLine + "SSID: aa:aa" + Environment.NewLine + "CH ●●", "-51", "dbm" };
            string[] row2 = new string[] { "BSSID: " + Environment.NewLine + "SSID: bb:bb" + Environment.NewLine + "CH ●●", "-68", "dbm" };
            string[] row3 = new string[] { "BSSID: " + Environment.NewLine + "SSID: cc:cc" + Environment.NewLine + "CH ●●", "-51", "dbm" };
            string[] row4 = new string[] { "BSSID: " + Environment.NewLine + "SSID: dd:dd" + Environment.NewLine + "CH ●●", "-51", "dbm" };
            string[] row5 = new string[] { "BSSID: " + Environment.NewLine + "SSID: ee:ee" + Environment.NewLine + "CH ●●", "-51", "dbm" };
            string[] row6 = new string[] { "BSSID: " + Environment.NewLine + "SSID: ff:ff" + Environment.NewLine + "CH ●●", "-51", "dbm" };
            object[] rows = new object[] { row1, row2, row3, row4, row5, row6 };

            //文字の配置を設定
            wifilistView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            wifilistView.Columns[0].DefaultCellStyle.Font = new Font("ＭＳ ゴシック", 12);
            wifilistView.Columns[0].DefaultCellStyle.ForeColor = Color.LightGray;
            wifilistView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            wifilistView.Columns[1].DefaultCellStyle.Font = new Font("ＭＳ ゴシック", 20);
            wifilistView.Columns[1].DefaultCellStyle.ForeColor = Color.Blue; // #FF0000FF
            wifilistView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            wifilistView.Columns[2].DefaultCellStyle.Font = new Font("ＭＳ ゴシック", 12);
            wifilistView.Columns[2].DefaultCellStyle.ForeColor = Color.LightGray;

            //セルの背景色
            wifilistView.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            wifilistView.Columns[1].DefaultCellStyle.BackColor = Color.Black;
            wifilistView.Columns[2].DefaultCellStyle.BackColor = Color.Black;


            for (int i = 0; i < rows.Length; i++)
            {
                string[] rowArray = (String[])rows[i];
                wifilistView.Rows.Add(rowArray);
                if (rowArray[1].Equals("-68"))
                {
                    //色を変える。
                    wifilistView.Rows[i].Cells[1].Style.ForeColor = Color.Green;
                }
            }


            //通常のセルコンテンツに対応するように行の高さを調整
            wifilistView.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);


            //描画されたら
            wifilistView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(WifilistView_RowPostPaint);

            wifilistView.CellPainting += new DataGridViewCellPaintingEventHandler(WifilistView_CellPaint);

            //wifilistView.Rows.Clear();
        }

        private void WifilistView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            DataGridViewColumn column1 = wifilistView.Columns[0];
            DataGridViewColumn column2 = wifilistView.Columns[1];
            DataGridViewColumn column3 = wifilistView.Columns[2];

            //線を引く位置を計算
            int startX = dgv.RowHeadersVisible ? dgv.RowHeadersWidth : 0;
            int startY = e.RowBounds.Top + e.RowBounds.Height - 1;
            int startYTop = e.RowBounds.Top;

            //上線をひく
            e.Graphics.DrawLine(
                new Pen(Color.LightGray, 2), //線の色
                startX + 2,                      //最初の点の x 座標。
                startYTop + 2,                   //最初の点の y 座標。
                startX + column1.Width + column2.Width + column3.Width - 2, //2点目の x座標。
                startYTop + 2                     //2点目の y座標。
            );

            //下線をひく
            e.Graphics.DrawLine(
                new Pen(Color.LightGray, 2), //線の色
                startX + 2,                      //最初の点の x 座標。
                startY - 2,                   //最初の点の y 座標。
                startX + column1.Width + column2.Width + column3.Width - 2, //2点目の x座標。
                startY - 2                    //2点目の y座標。
            );

            //左線をひく
            e.Graphics.DrawLine(
                new Pen(Color.LightGray, 2), //線の色
                startX + 2,                      //最初の点の x 座標。
                startYTop + 2,                   //最初の点の y 座標。
                startX + 2, //2点目の x座標。
                startY + 2                      //2点目の y座標。
            );

            //右線をひく
            e.Graphics.DrawLine(
               new Pen(Color.LightGray, 2), //線の色
               startX + column1.Width + column2.Width + column3.Width - 2,                      //最初の点の x 座標。
               startYTop - 2,                   //最初の点の y 座標。
               startX + column1.Width + column2.Width + column3.Width - 2,   //2点目の x座標。
               startY - 2                      //2点目の y座標。
           );
        }

        private void WifilistView_CellPaint(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            Debug.WriteLine("WifilistView_CellPaint:" + e.RowIndex + " " + e.Value);
            Debug.WriteLine(" ");
            String moji = (String) e.Value;
            Debug.WriteLine("WifilistView_CellPaint:moji:" + moji);
            Debug.WriteLine(" ");

            String ssid_moji = "SSID: ";

            if (moji.IndexOf(ssid_moji) != -1)
            {
                String[] Mojisplit = moji.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                if (Mojisplit[1].IndexOf(ssid_moji) != -1)
                {
                    SolidBrush charBrush;
                    SolidBrush foreBrush;
                    SolidBrush backBrush;
                    SolidBrush blueBrush = new SolidBrush(Color.Blue);

                    //選択されている場合
                    if (e.State == DataGridViewElementStates.Selected)
                    {
                        foreBrush = new SolidBrush(e.CellStyle.SelectionForeColor);
                        backBrush = new SolidBrush(e.CellStyle.SelectionBackColor);
                    } else
                    {
                        foreBrush = new SolidBrush(e.CellStyle.ForeColor);
                        backBrush = new SolidBrush(e.CellStyle.BackColor);
                    }

                    e.Graphics.FillRectangle(backBrush, e.CellBounds);

                    e.Graphics.DrawString(
                        Mojisplit[0] + Environment.NewLine,
                        e.CellStyle.Font,
                        foreBrush,
                        e.CellBounds.X,
                        e.CellBounds.Y + 2,
                        StringFormat.GenericDefault
                        );

                    //String.Lengthだと文字数なので注意
                    int length = Mojisplit[0].Length + 2;

                    e.Graphics.DrawString(
                        ssid_moji,
                        e.CellStyle.Font,
                        foreBrush,
                        e.CellBounds.X,
                        e.CellBounds.Y + e.CellStyle.Font.Height + 9,
                        StringFormat.GenericDefault
                        );

                    int length_ssid_moji = ssid_moji.Length;

                    String Mojireplace = Mojisplit[1].Replace(ssid_moji, "");


                    Debug.WriteLine("Mojireplace:" + Mojireplace);
                    if (Mojireplace.Equals("cc:cc"))
                    {
                        charBrush = blueBrush;
                    } 
                    else
                    {
                        charBrush = foreBrush;
                    }

                    e.Graphics.DrawString(
                        Mojireplace + Environment.NewLine,
                        e.CellStyle.Font,
                        charBrush,
                        e.CellBounds.X + e.CellStyle.Font.Size * length_ssid_moji /2 + 4,
                        e.CellBounds.Y + e.CellStyle.Font.Height + 9,
                        StringFormat.GenericDefault
                        );


                    e.Graphics.DrawString(
                       Mojisplit[2],
                       e.CellStyle.Font,
                       foreBrush,
                       e.CellBounds.X,
                       e.CellBounds.Y + (e.CellStyle.Font.Height + 9)*2,
                       StringFormat.GenericDefault
                       );


                    foreBrush.Dispose();
                    backBrush.Dispose();
                    blueBrush.Dispose();

                    e.Handled = true;
                }
            }
        }

        //バイト数を取得
        private static int LenB(string str)
        {
            //Shift JISに変換したときに必要なバイト数を返す
            return System.Text.Encoding.GetEncoding(932).GetByteCount(str);
        }
    }
}
