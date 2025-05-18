using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDataReader;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.Globalization;


namespace Trabalho_Oficial
{
    public partial class Form1 : Form
    {
        private string filePath = "Alunos.txt";
        private List<Aluno> alunos = new List<Aluno>();
        private Aluno alunoEditando = null;
        public Form1()
        {
            InitializeComponent();
            VerificarArquivo();
            CarregarAlunos();
            AtualizarListaAlunos();
            AtualizarListaFiltrada();
        }

        private void AtualizarListaFiltrada()
        {
            string nome = txtPesquisaNome.Text.Trim();
            string matriculaStr = txtPesquisaMatricula.Text.Trim();
            List<Aluno> resultados = new List<Aluno>();

            // Flag que determina se o campo de nome está preenchido
            bool temNome = !string.IsNullOrEmpty(nome);

            // Flag que verifica se a matrícula é válida
            bool temMatricula = int.TryParse(matriculaStr, out int matricula);

            if (temNome && temMatricula)
            {
                // Filtro por nome e matrícula
                resultados = alunos.Where(a =>
                    a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase) &&
                    a.Matricula == matricula).ToList();
            }
            else if (temNome)
            {
                // Filtro somente por nome
                resultados = alunos.Where(a =>
                    a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else if (temMatricula)
            {
                // Filtro somente por matrícula
                resultados = alunos.Where(a => a.Matricula == matricula).ToList();
            }
            else
            {
                // Nenhum filtro: mostra todos os alunos
                resultados = alunos.OrderBy(a => a.Nome).ToList();
            }

            // Atualiza a lista exibida
            listBoxAlunos.Items.Clear();
            foreach (var aluno in resultados)
            {
                listBoxAlunos.Items.Add(FormatarAluno(aluno));
            }
        }


        private void VerificarArquivo()
        {
            if (!File.Exists(filePath))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine("Cadastro de alunos");
                        sw.WriteLine("Alunos cadastrados: 0");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao criar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CarregarAlunos()
        {
            alunos.Clear();
            try
            {
                string[] linhas = File.ReadAllLines(filePath);
                for (int i = 2; i < linhas.Length; i++)
                {
                    var dados = linhas[i].Split('|');
                    if (dados.Length == 5)
                    {
                        var aluno = new Aluno
                        {
                            Nome = dados[0].Split(':')[1].Trim(),
                            Idade = int.Parse(dados[1].Split(':')[1].Trim()),
                            Curso = dados[2].Split(':')[1].Trim(),
                            Matricula = int.Parse(dados[3].Split(':')[1].Trim()),
                            Nota = int.Parse(dados[4].Split(':')[1].Trim())
                        };
                        alunos.Add(aluno);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ler o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvarAlunos()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine("Cadastro de alunos");
                    sw.WriteLine($"Alunos cadastrados: {alunos.Count}");
                    foreach (var aluno in alunos)
                    {
                        sw.WriteLine(FormatarAluno(aluno));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os alunos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AtualizarListaAlunos();
        }

        private void AtualizarListaAlunos()
        {
            listBoxAlunos.Items.Clear();
            foreach (var aluno in alunos)
            {
                listBoxAlunos.Items.Add(FormatarAluno(aluno));
            }
            lbl_ContagemAlunos.Text = $"Alunos cadastrados: {alunos.Count}";
        }

        private string FormatarAluno(Aluno a)
        {
            return $"Nome: {a.Nome} | Idade: {a.Idade} | Curso: {a.Curso} | Matrícula: {a.Matricula} | Nota: {a.Nota}";
        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtCurso.Text) ||
                !int.TryParse(txtIdade.Text, out _) ||
                !int.TryParse(txtMatricula.Text, out _) ||
                !int.TryParse(txtNota.Text, out _))
            {
                MessageBox.Show("Preencha corretamente todos os campos.");
                return false;
            }
            return true;
        }

        private void LimparCamposCadastro()
        {
            txtNome.Clear();
            txtIdade.Clear();
            txtCurso.Clear();
            txtMatricula.Clear();
            txtNota.Clear();
        }

        private void PreencherCampos(Aluno aluno)
        {
            txtNome.Text = aluno.Nome;
            txtIdade.Text = aluno.Idade.ToString();
            txtCurso.Text = aluno.Curso;
            txtMatricula.Text = aluno.Matricula.ToString();
            txtNota.Text = aluno.Nota.ToString();
        }

        public class Aluno
        {
            public string Nome { get; set; }
            public int Idade { get; set; }
            public string Curso { get; set; }
            public int Matricula { get; set; }
            public int Nota { get; set; }

            public override string ToString()
            {
                return $"{Matricula} - {Nome} - {Idade} anos - {Curso} - Nota: {Nota}";
            }
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            string nome = txtPesquisaNome.Text.Trim();
            string matriculaStr = txtPesquisaMatricula.Text.Trim();
            List<Aluno> resultados = new List<Aluno>();

            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(matriculaStr))
            {
                if (int.TryParse(matriculaStr, out int matricula))
                {
                    resultados = alunos.Where(a =>
                        a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase) &&
                        a.Matricula == matricula).ToList();
                }
                else
                {
                    MessageBox.Show("Matrícula inválida.");
                }
            }
            else if (!string.IsNullOrEmpty(nome))
            {
                resultados = alunos.Where(a => a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else if (int.TryParse(matriculaStr, out int matricula))
            {
                resultados = alunos.Where(a => a.Matricula == matricula).ToList();
            }
            else
            {
                // Nenhum filtro: exibir todos os alunos
                resultados = alunos.OrderBy(a => a.Nome).ToList();
            }

            if (resultados.Any())
            {
                listBoxAlunos.Items.Clear();
                foreach (var aluno in resultados)
                {
                    listBoxAlunos.Items.Add(FormatarAluno(aluno));
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Nenhum aluno encontrado. Deseja cadastrar?", "Aluno não encontrado", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    LimparCamposCadastro();
                    groupBoxCadastro.Visible = true;
                    groupBoxCadastro.Enabled = true;
                }
            }
        }

        private void listBoxAlunos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxAlunos.SelectedIndex >= 0)
            {
                string linha = listBoxAlunos.SelectedItem.ToString();
                int matricula = int.Parse(linha.Split('|')[3].Split(':')[1].Trim());
                alunoEditando = alunos.FirstOrDefault(a => a.Matricula == matricula);
            }
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (alunoEditando != null)
            {
                PreencherCampos(alunoEditando);
                groupBoxCadastro.Visible = true;
            }
            else
            {
                MessageBox.Show("Selecione um aluno para editar.");
            }
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (alunoEditando == null)
            {
                MessageBox.Show("Selecione um aluno para excluir.");
                return;
            }

            var confirmacao = MessageBox.Show("Deseja excluir o aluno?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmacao == DialogResult.Yes)
            {
                alunos.Remove(alunoEditando);
                alunoEditando = null;
                SalvarAlunos();
            }
        }

        private void btnVerificarAprovacao_Click_1(object sender, EventArgs e)
        {
            if (alunoEditando != null)
            {
                string status = alunoEditando.Nota >= 70 ? "Aprovado" : "Reprovado";
                MessageBox.Show($"Aluno está {status} (Nota: {alunoEditando.Nota})");
            }
            else
            {
                MessageBox.Show("Selecione um aluno para verificar.");
            }
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int matricula = int.Parse(txtMatricula.Text);

            if (alunos.Any(a => a.Matricula == matricula && a != alunoEditando))
            {
                MessageBox.Show("Matrícula já cadastrada.");
                return;
            }

            if (alunoEditando != null)
            {
                alunoEditando.Nome = txtNome.Text;
                alunoEditando.Idade = int.Parse(txtIdade.Text);
                alunoEditando.Curso = txtCurso.Text;
                alunoEditando.Matricula = matricula;
                alunoEditando.Nota = int.Parse(txtNota.Text);
                alunoEditando = null;
                MessageBox.Show("Aluno atualizado.");
            }
            else
                alunos.Add(new Aluno
                {
                    Nome = txtNome.Text,
                    Idade = int.Parse(txtIdade.Text),
                    Curso = txtCurso.Text,
                    Matricula = matricula,
                    Nota = int.Parse(txtNota.Text)
                });


            SalvarAlunos();
            groupBoxCadastro.Visible = false;
        }

        private void btnNovoAluno_Click_1(object sender, EventArgs e)
        {
            LimparCamposCadastro();
            alunoEditando = null;
            groupBoxCadastro.Visible = true;
            groupBoxCadastro.Enabled = true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!alunos.Any())
            {
                lblRelatorio.Text = "Nenhum aluno cadastrado.";
                return;
            }

            int aprovados = alunos.Count(a => a.Nota >= 70);
            int reprovados = alunos.Count - aprovados;
            double media = alunos.Average(a => a.Nota);
            int max = alunos.Max(a => a.Nota);
            int min = alunos.Min(a => a.Nota);

            lblRelatorio.Text = $"Total: {alunos.Count}\n" +
                                $"Aprovados: {aprovados} ({aprovados * 100.0 / alunos.Count:0.##}%)\n" +
                                $"Reprovados: {reprovados} ({reprovados * 100.0 / alunos.Count:0.##}%)\n" +
                                $"Média: {media:0.00}\nMáxima: {max}\nMínima: {min}";

            btnAprovados.Enabled = true;
            btnAprovados.Visible = true;
            btnReprovados.Enabled = true;
            btnReprovados.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            groupBoxCadastro.Visible = false;
            alunoEditando = null;
        }

        private void btn_Procurar_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto ou Excel (*.txt;*.xlsx;*.xls)|*.txt;*.xlsx;*.xls|Todos os Arquivos (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txt_Caminho.Text = openFileDialog.FileName;
                }
            }
        }

        private void btn_Importar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Caminho.Text))
            {
                MessageBox.Show("Por favor, selecione um arquivo primeiro.");
                return;
            }

            string extensao = Path.GetExtension(txt_Caminho.Text);

            // Lista para armazenar mensagens de erro ou aviso
            List<string> mensagensErro = new List<string>();

            // === Importação de Excel (.xlsx/.xls) ===
            if (extensao.Equals(".xlsx", StringComparison.OrdinalIgnoreCase) || extensao.Equals(".xls", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                    using (var stream = File.Open(txt_Caminho.Text, FileMode.Open, FileAccess.Read))
                    using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        var table = result.Tables[0];

                        // --- Função auxiliar para remover acentos das colunas ---
                        string RemoverAcentos(string texto)
                        {
                            return new string(texto.Normalize(NormalizationForm.FormD)
                                              .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                              .ToArray());
                        }

                        // --- Mapeia os nomes das colunas ignorando acentos e caixa ---
                        var colunas = table.Columns.Cast<DataColumn>()
                            .ToDictionary(c => RemoverAcentos(c.ColumnName.Trim().ToLower()), c => c.ColumnName);

                        // --- Verifica se todas as colunas esperadas existem ---
                        string[] esperadas = { "nome", "idade", "curso", "matricula", "nota" };
                        foreach (var col in esperadas)
                        {
                            if (!colunas.ContainsKey(col))
                            {
                                mensagensErro.Add($"A coluna '{col}' não foi encontrada na planilha.\nVerifique os nomes das colunas.");
                            }
                        }

                        // --- Processa as linhas da planilha ---
                        foreach (DataRow row in table.Rows)
                        {
                            try
                            {
                                var aluno = new Aluno
                                {
                                    Nome = row[colunas["nome"]].ToString().Trim(),
                                    Idade = int.Parse(row[colunas["idade"]].ToString()),
                                    Curso = row[colunas["curso"]].ToString().Trim(),
                                    Matricula = int.Parse(row[colunas["matricula"]].ToString()),
                                    Nota = int.Parse(row[colunas["nota"]].ToString())
                                };

                                if (!alunos.Any(a => a.Matricula == aluno.Matricula))
                                    alunos.Add(aluno);
                                else
                                    mensagensErro.Add($"Aluno com matrícula {aluno.Matricula} já existe no sistema. Linha ignorada.");
                            }
                            catch (Exception ex)
                            {
                                mensagensErro.Add($"Erro ao importar aluno da planilha: {ex.Message}");
                            }
                        }
                    }

                    SalvarAlunos();
                    mensagensErro.Add("Importação da planilha concluída com sucesso!");
                }
                catch (Exception ex)
                {
                    mensagensErro.Add("Erro ao importar arquivo Excel: " + ex.Message);
                }

                return;
            }

            // === Importação de arquivo .txt ===
            try
            {
                if (alunos == null)
                    alunos = new List<Aluno>();

                List<int> matriculasImportadas = new List<int>();
                List<string> dadosImportados = new List<string>();

                using (StreamReader sr = new StreamReader(txt_Caminho.Text, Encoding.UTF8))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        linha = linha.Trim();

                        if (string.IsNullOrEmpty(linha))
                            continue;

                        bool formatoAntigo = linha.Contains("Nome:") && linha.Contains("Idade:");
                        string[] dados;

                        if (formatoAntigo)
                        {
                            string linhaComPipes = linha.Replace(',', '|');
                            dados = linhaComPipes.Split('|');
                        }
                        else
                        {
                            dados = linha.Split(',');
                        }

                        if (dados.Length == 5)
                        {
                            try
                            {
                                int matricula;

                                if (formatoAntigo)
                                    matricula = int.Parse(dados[3].Split(':')[1].Trim());
                                else
                                    matricula = int.Parse(dados[3].Trim());

                                if (matriculasImportadas.Contains(matricula))
                                {
                                    mensagensErro.Add($"Matrícula duplicada no arquivo: {matricula}. Esta linha será ignorada.");
                                    continue;
                                }

                                matriculasImportadas.Add(matricula);
                                dadosImportados.Add(linha);
                            }
                            catch (Exception ex)
                            {
                                mensagensErro.Add($"Erro ao processar a linha:\n{linha}\n\nErro: {ex.Message}");
                            }
                        }
                        else
                        {
                            mensagensErro.Add($"Linha com formato inválido ignorada:\n{linha}");
                        }
                    }
                }

                foreach (var linha in dadosImportados)
                {
                    bool formatoAntigo = linha.Contains("Nome:") && linha.Contains("Idade:");
                    string[] dados;

                    if (formatoAntigo)
                    {
                        string linhaComPipes = linha.Replace(',', '|');
                        dados = linhaComPipes.Split('|');
                    }
                    else
                    {
                        dados = linha.Split(',');
                    }

                    try
                    {
                        Aluno aluno;

                        if (formatoAntigo)
                        {
                            aluno = new Aluno
                            {
                                Nome = dados[0].Split(':')[1].Trim(),
                                Idade = int.Parse(dados[1].Split(':')[1].Trim()),
                                Curso = dados[2].Split(':')[1].Trim(),
                                Matricula = int.Parse(dados[3].Split(':')[1].Trim()),
                                Nota = int.Parse(dados[4].Split(':')[1].Trim())
                            };
                        }
                        else
                        {
                            aluno = new Aluno
                            {
                                Nome = dados[0].Trim(),
                                Idade = int.Parse(dados[1].Trim()),
                                Curso = dados[2].Trim(),
                                Matricula = int.Parse(dados[3].Trim()),
                                Nota = int.Parse(dados[4].Trim())
                            };
                        }

                        if (!alunos.Any(a => a.Matricula == aluno.Matricula))
                            alunos.Add(aluno);
                        else
                            mensagensErro.Add($"Aluno com matrícula {aluno.Matricula} já existe no sistema. Linha ignorada.");
                    }
                    catch (Exception ex)
                    {
                        mensagensErro.Add($"Erro ao processar a linha:\n{linha}\n\nErro: {ex.Message}");
                    }
                }

                SalvarAlunos();
                mensagensErro.Add("Dados importados e salvos com sucesso!");
            }
            catch (Exception ex)
            {
                mensagensErro.Add("Erro ao importar os dados: " + ex.Message);
            }

            // Exibe todas as mensagens acumuladas em uma única MessageBox
            if (mensagensErro.Any())
            {
                MessageBox.Show(string.Join("\n", mensagensErro), "Resultado da Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtPesquisaNome_Enter(object sender, EventArgs e)
        {
            if (txtPesquisaNome.Text == "Pesquisar nome...")
            {
                txtPesquisaNome.Text = "";
                txtPesquisaNome.ForeColor = Color.Black;
            }
        }

        private void txtPesquisaNome_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisaNome.Text))
            {
                txtPesquisaNome.Text = "Pesquisar nome...";
                txtPesquisaNome.ForeColor = Color.Gray;
            }
        }

        private void btnAprovados_Click(object sender, EventArgs e)
        {
            listBoxAR.Items.Clear();
            var aprovados = alunos.Where(a => a.Nota >= 70).ToList();
            foreach (var aluno in aprovados)
            {
                listBoxAR.Items.Add(FormatarAluno(aluno));
            }
            listBoxAR.Enabled = true;
            listBoxAR.Visible = true;
        }

        private void btnReprovados_Click(object sender, EventArgs e)
        {
            listBoxAR.Items.Clear();
            var reprovados = alunos.Where(a => a.Nota <= 69).ToList();
            foreach (var aluno in reprovados)
            {
                listBoxAR.Items.Add(FormatarAluno(aluno));
            }
            listBoxAR.Enabled = true;
            listBoxAR.Visible = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (alunos.Count == 0)
            {
                MessageBox.Show("Nenhum aluno cadastrado para gerar o relatório.");
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Salvar Relatório em PDF";
                saveFileDialog.FileName = "RelatorioAlunos.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Criação do documento PDF
                        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                        PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                        doc.Open();

                        // Título
                        var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        Paragraph title = new Paragraph("Relatório\n\n", titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(title);

                        // Texto do lblRelatorio
                        var regularFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                        Paragraph relatorioTexto = new Paragraph(lblRelatorio.Text + "\n\n", regularFont);
                        doc.Add(relatorioTexto);

                        // Tabela com os dados dos alunos
                        PdfPTable table = new PdfPTable(5); // 5 colunas
                        table.WidthPercentage = 100;
                        table.SetWidths(new float[] { 2f, 1f, 2f, 1.5f, 1f });

                        // Cabeçalhos
                        string[] cabecalhos = { "Nome", "Idade", "Curso", "Matrícula", "Nota" };
                        foreach (string col in cabecalhos)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cell);
                        }

                        // Dados dos alunos ordenados por nome
                        foreach (var aluno in alunos.OrderBy(a => a.Nome))
                        {
                            table.AddCell(new Phrase(aluno.Nome));
                            table.AddCell(aluno.Idade.ToString());
                            table.AddCell(aluno.Curso);
                            table.AddCell(aluno.Matricula.ToString());
                            table.AddCell(aluno.Nota.ToString());
                        }

                        doc.Add(table);

                        // Separar aprovados e reprovados
                        var alunosAprovados = alunos.Where(a => a.Nota >= 70).OrderBy(a => a.Nome).ToList();
                        var alunosReprovados = alunos.Where(a => a.Nota <= 69).OrderBy(a => a.Nome).ToList();

                        // Espaço antes da nova seção
                        doc.Add(new Paragraph("\n\n"));

                        // Tabela de Aprovados
                        Paragraph aprovadosTitle = new Paragraph("Alunos Aprovados\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                        doc.Add(aprovadosTitle);

                        PdfPTable tabelaAprovados = new PdfPTable(5);
                        tabelaAprovados.WidthPercentage = 100;
                        tabelaAprovados.SetWidths(new float[] { 2f, 1f, 2f, 1.5f, 1f });

                        foreach (string col in cabecalhos)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            tabelaAprovados.AddCell(cell);
                        }

                        foreach (var aluno in alunosAprovados)
                        {
                            tabelaAprovados.AddCell(new Phrase(aluno.Nome));
                            tabelaAprovados.AddCell(aluno.Idade.ToString());
                            tabelaAprovados.AddCell(aluno.Curso);
                            tabelaAprovados.AddCell(aluno.Matricula.ToString());
                            tabelaAprovados.AddCell(aluno.Nota.ToString());
                        }

                        doc.Add(tabelaAprovados);

                        // Espaço antes da próxima seção
                        doc.Add(new Paragraph("\n\n"));

                        // Tabela de Reprovados
                        Paragraph reprovadosTitle = new Paragraph("Alunos Reprovados\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                        doc.Add(reprovadosTitle);

                        PdfPTable tabelaReprovados = new PdfPTable(5);
                        tabelaReprovados.WidthPercentage = 100;
                        tabelaReprovados.SetWidths(new float[] { 2f, 1f, 2f, 1.5f, 1f });

                        foreach (string col in cabecalhos)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            tabelaReprovados.AddCell(cell);
                        }

                        foreach (var aluno in alunosReprovados)
                        {
                            tabelaReprovados.AddCell(new Phrase(aluno.Nome));
                            tabelaReprovados.AddCell(aluno.Idade.ToString());
                            tabelaReprovados.AddCell(aluno.Curso);
                            tabelaReprovados.AddCell(aluno.Matricula.ToString());
                            tabelaReprovados.AddCell(aluno.Nota.ToString());
                        }

                        doc.Add(tabelaReprovados);

                        doc.Close();

                        MessageBox.Show("Relatório PDF gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao gerar o PDF: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtPesquisaNome_TextChanged(object sender, EventArgs e)
        {
            AtualizarListaFiltrada();
        }

        private void txtPesquisaMatricula_TextChanged(object sender, EventArgs e)
        {
            AtualizarListaFiltrada();
        }
    }
}
