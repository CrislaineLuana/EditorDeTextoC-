using System.IO;


namespace editorDeTexto
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;
        string nome_da_fonte = null;
        float tamanho_da_fonte = 0;
        bool negrito = false;
        bool italico = false;
        bool sublinhado = false;

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
            if (this.richTextBox1.Text == "")
            {
                return;
            } 
            else
            {
                DialogResult result = MessageBox.Show("Deseja salvar o arquivo atual? ", "Atenção", MessageBoxButtons.YesNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        Salvar();
                        break;
                    case DialogResult.No:
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

        private void Copiar()
        {
            if (this.richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Recortar()
        {
            if(this.richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void btn_Recortar_Click(object sender, EventArgs e)
        {
            Recortar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recortar();
        }

        private void Negrito() 
        {

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            negrito = richTextBox1.Font.Bold;

            if (negrito == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
            } 
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            }


        }

        private void Italico()
        {
            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            italico = richTextBox1.Font.Italic;

            if (italico == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
            }
        }

        private void Sublinhado()
        {

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            sublinhado = richTextBox1.Font.Underline;

            if (italico == false)
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
            }
            else
            {
                richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
            }
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }
    }
}