using System.IO;


namespace editorDeTexto
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void verificaSalvamento()
        {
            int salvar = 0;
            if (this.richTextBox1.Text == "")
            {
                return;
            } 
            else
            {
                DialogResult result = MessageBox.Show("Deseja salvar o arquivo atual? ", "Atenção", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        Salvar();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        break;

                }
                     

            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {


            verificaSalvamento();
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verificaSalvamento();
            Novo();
        }

        private void Salvar()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(arquivo);
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    sw.Write(this.richTextBox1.Text);
                    sw.Flush();
                    sw.Close();
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Erro na gravação " + ex.Message, "Erro ao Gravar" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Abrir Arquivo";

            openFileDialog1.InitialDirectory = @"D:\docs";

            openFileDialog1.Filter = "(*.TXT)|*.TXT";

            if(this.openFileDialog1.ShowDialog() == DialogResult.OK) { 

                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(arquivo);
                  
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";

                    string linha = sr.ReadLine();
                    
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = sr.ReadLine();
                    }

                    sr.Close();

                } 
                catch(Exception ex)
                {
                    MessageBox.Show("Erro de leitua do arquivo");
                }

            }

        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abnrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }
    }
}