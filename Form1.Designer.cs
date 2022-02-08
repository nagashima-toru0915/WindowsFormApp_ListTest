
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";


            this.wifilistView = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // wifilistView
            // 
            this.wifilistView.Show();  //表示する
            this.wifilistView.Location = new System.Drawing.Point(56, 34); //表示場所の開始位置
            this.wifilistView.Name = "wifilistView"; //Formの名称
            this.wifilistView.Size = new System.Drawing.Size(400, 300); //サイズ
            this.wifilistView.TabIndex = 0; //タブを押したときの順番
        }

        #endregion

        private System.Windows.Forms.DataGridView wifilistView;
    }
}

