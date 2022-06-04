using System.IO;


namespace editorDeTexto
{
    public partial class Form1 : Form
    {

        StringReader leitura = null;

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
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito, italico, sublinhado = false;
            
            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            if (negrito == false)
            {
                if(italico == true && sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                } else if (italico == true && sublinhado == false)
                {

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);

                } else if (italico == false && sublinhado == true)
                {

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);

                } else if (italico == false && sublinhado == false){

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);

                }

              
            } 
            else
            {
                if (italico == true && sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte,FontStyle.Italic | FontStyle.Underline);

                }
                else if (italico == true && sublinhado == false)
                {

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);

                }
                else if (italico == false && sublinhado == true)
                {

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);

                }
               
            }


        }

        private void Italico()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito, italico, sublinhado = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            if (italico == false)
            {
                if (negrito == true && sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true && sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (negrito == false && sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false && sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
            else
            {
                if (negrito == true && sublinhado == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (negrito == true && sublinhado == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);

                }
                else if (negrito == false && sublinhado == true)
                {

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }

            }
        }

        private void Sublinhado()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool negrito, italico, sublinhado = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;

            negrito = richTextBox1.SelectionFont.Bold;
            italico = richTextBox1.SelectionFont.Italic;
            sublinhado = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);
            if (sublinhado == false)
            {
                if (negrito == true && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (negrito == false && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == false && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
            }
            else
            {
                if (negrito == true && italico == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (negrito == true && italico == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);

                }
                else if (negrito == false && italico == true)
                {

                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }

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

        private void alinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment= HorizontalAlignment.Center;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_centralizado_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }


        private void imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);

            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float posicionamentoY = 0;
            int contador = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemTop = e.MarginBounds.Top - 50;

            if(margemEsquerda < 5)
            {
                margemEsquerda = 20;
            } 

            if(margemTop < 5)
            {
                margemTop = 20;
            }

            string linha = null;
            Font font = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);

            linhasPagina = e.MarginBounds.Height / font.GetHeight(e.Graphics);

            linha = leitura.ReadLine();

            while(contador < linhasPagina)
            {
                posicionamentoY = (margemTop + (contador * font.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, font, pincel, margemEsquerda, posicionamentoY, new StringFormat());
                contador++;

                linha = leitura.ReadLine();
            }

            if(linha != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

            pincel.Dispose();

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void btn_tamanho_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void btn_fonte_Click(object sender, EventArgs e)
        {
            var formato = fontDialog1.ShowDialog();
            if(formato == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void btn_cor_Click(object sender, EventArgs e)
        {
            var cor = colorDialog1.ShowDialog();
            if(cor == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }
    }
}