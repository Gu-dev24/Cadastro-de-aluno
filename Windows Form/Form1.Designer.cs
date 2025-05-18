using System.Windows.Forms;

namespace Trabalho_Oficial
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnVerificarAprovacao = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnNovoAluno = new Button();
            btnPesquisar = new Button();
            txtPesquisaMatricula = new TextBox();
            txtPesquisaNome = new TextBox();
            groupBoxCadastro = new GroupBox();
            btnSalvar = new Button();
            btnCancelar = new Button();
            txtNota = new TextBox();
            txtMatricula = new TextBox();
            txtCurso = new TextBox();
            txtIdade = new TextBox();
            txtNome = new TextBox();
            lbl_ContagemAlunos = new Label();
            listBoxAlunos = new ListBox();
            tabPage2 = new TabPage();
            btnDownload = new Button();
            listBoxAR = new ListBox();
            btnAprovados = new Button();
            btnReprovados = new Button();
            btnAtualizar = new Button();
            lblRelatorio = new Label();
            tabPage3 = new TabPage();
            label1 = new Label();
            btn_Importar = new Button();
            btn_Procurar = new Button();
            txt_Caminho = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBoxCadastro.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(939, 605);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnVerificarAprovacao);
            tabPage1.Controls.Add(btnExcluir);
            tabPage1.Controls.Add(btnEditar);
            tabPage1.Controls.Add(btnNovoAluno);
            tabPage1.Controls.Add(btnPesquisar);
            tabPage1.Controls.Add(txtPesquisaMatricula);
            tabPage1.Controls.Add(txtPesquisaNome);
            tabPage1.Controls.Add(groupBoxCadastro);
            tabPage1.Controls.Add(lbl_ContagemAlunos);
            tabPage1.Controls.Add(listBoxAlunos);
            tabPage1.Dock = DockStyle.Fill;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(931, 572);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Cadastro";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnVerificarAprovacao
            // 
            btnVerificarAprovacao.Location = new Point(757, 179);
            btnVerificarAprovacao.Name = "btnVerificarAprovacao";
            btnVerificarAprovacao.Size = new Size(94, 29);
            btnVerificarAprovacao.TabIndex = 9;
            btnVerificarAprovacao.Text = "Aprovação";
            btnVerificarAprovacao.UseVisualStyleBackColor = true;
            btnVerificarAprovacao.Click += btnVerificarAprovacao_Click_1;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(757, 139);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(94, 29);
            btnExcluir.TabIndex = 8;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click_1;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(757, 99);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click_1;
            // 
            // btnNovoAluno
            // 
            btnNovoAluno.Location = new Point(757, 59);
            btnNovoAluno.Name = "btnNovoAluno";
            btnNovoAluno.Size = new Size(94, 29);
            btnNovoAluno.TabIndex = 6;
            btnNovoAluno.Text = "Novo";
            btnNovoAluno.UseVisualStyleBackColor = true;
            btnNovoAluno.Click += btnNovoAluno_Click_1;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Enabled = false;
            btnPesquisar.Location = new Point(402, 16);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(94, 29);
            btnPesquisar.TabIndex = 5;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Visible = false;
            btnPesquisar.Click += btnPesquisar_Click_1;
            // 
            // txtPesquisaMatricula
            // 
            txtPesquisaMatricula.Location = new Point(198, 16);
            txtPesquisaMatricula.Name = "txtPesquisaMatricula";
            txtPesquisaMatricula.PlaceholderText = "Matrícula";
            txtPesquisaMatricula.Size = new Size(180, 27);
            txtPesquisaMatricula.TabIndex = 4;
            txtPesquisaMatricula.TextChanged += txtPesquisaMatricula_TextChanged;
            // 
            // txtPesquisaNome
            // 
            txtPesquisaNome.Location = new Point(3, 16);
            txtPesquisaNome.Name = "txtPesquisaNome";
            txtPesquisaNome.PlaceholderText = "Nome";
            txtPesquisaNome.Size = new Size(180, 27);
            txtPesquisaNome.TabIndex = 3;
            txtPesquisaNome.TextChanged += txtPesquisaNome_TextChanged;
            txtPesquisaNome.Enter += txtPesquisaNome_Enter;
            txtPesquisaNome.Leave += txtPesquisaNome_Leave;
            // 
            // groupBoxCadastro
            // 
            groupBoxCadastro.Controls.Add(btnSalvar);
            groupBoxCadastro.Controls.Add(btnCancelar);
            groupBoxCadastro.Controls.Add(txtNota);
            groupBoxCadastro.Controls.Add(txtMatricula);
            groupBoxCadastro.Controls.Add(txtCurso);
            groupBoxCadastro.Controls.Add(txtIdade);
            groupBoxCadastro.Controls.Add(txtNome);
            groupBoxCadastro.Enabled = false;
            groupBoxCadastro.Location = new Point(3, 334);
            groupBoxCadastro.Name = "groupBoxCadastro";
            groupBoxCadastro.Size = new Size(626, 225);
            groupBoxCadastro.TabIndex = 2;
            groupBoxCadastro.TabStop = false;
            groupBoxCadastro.Text = "Cadastro";
            groupBoxCadastro.Visible = false;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(426, 190);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 29);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(526, 190);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNota
            // 
            txtNota.Location = new Point(6, 158);
            txtNota.Name = "txtNota";
            txtNota.PlaceholderText = "Nota";
            txtNota.Size = new Size(216, 27);
            txtNota.TabIndex = 4;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(6, 125);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.PlaceholderText = "Matrícula";
            txtMatricula.Size = new Size(216, 27);
            txtMatricula.TabIndex = 3;
            // 
            // txtCurso
            // 
            txtCurso.Location = new Point(6, 92);
            txtCurso.Name = "txtCurso";
            txtCurso.PlaceholderText = "Curso";
            txtCurso.Size = new Size(216, 27);
            txtCurso.TabIndex = 2;
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(6, 59);
            txtIdade.Name = "txtIdade";
            txtIdade.PlaceholderText = "Idade";
            txtIdade.Size = new Size(216, 27);
            txtIdade.TabIndex = 1;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(6, 26);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new Size(216, 27);
            txtNome.TabIndex = 0;
            // 
            // lbl_ContagemAlunos
            // 
            lbl_ContagemAlunos.AutoSize = true;
            lbl_ContagemAlunos.Location = new Point(6, 286);
            lbl_ContagemAlunos.Name = "lbl_ContagemAlunos";
            lbl_ContagemAlunos.Size = new Size(0, 20);
            lbl_ContagemAlunos.TabIndex = 1;
            // 
            // listBoxAlunos
            // 
            listBoxAlunos.FormattingEnabled = true;
            listBoxAlunos.Location = new Point(3, 59);
            listBoxAlunos.Name = "listBoxAlunos";
            listBoxAlunos.Size = new Size(693, 224);
            listBoxAlunos.TabIndex = 0;
            listBoxAlunos.SelectedIndexChanged += listBoxAlunos_SelectedIndexChanged_1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnDownload);
            tabPage2.Controls.Add(listBoxAR);
            tabPage2.Controls.Add(btnAprovados);
            tabPage2.Controls.Add(btnReprovados);
            tabPage2.Controls.Add(btnAtualizar);
            tabPage2.Controls.Add(lblRelatorio);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(931, 572);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Relatório";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(112, 6);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(100, 29);
            btnDownload.TabIndex = 5;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // listBoxAR
            // 
            listBoxAR.Enabled = false;
            listBoxAR.Location = new Point(218, 3);
            listBoxAR.Name = "listBoxAR";
            listBoxAR.Size = new Size(689, 264);
            listBoxAR.TabIndex = 0;
            listBoxAR.Visible = false;
            // 
            // btnAprovados
            // 
            btnAprovados.Enabled = false;
            btnAprovados.Location = new Point(112, 41);
            btnAprovados.Name = "btnAprovados";
            btnAprovados.Size = new Size(100, 29);
            btnAprovados.TabIndex = 4;
            btnAprovados.Text = "Aprovados";
            btnAprovados.UseVisualStyleBackColor = true;
            btnAprovados.Visible = false;
            btnAprovados.Click += btnAprovados_Click;
            // 
            // btnReprovados
            // 
            btnReprovados.Enabled = false;
            btnReprovados.Location = new Point(8, 41);
            btnReprovados.Name = "btnReprovados";
            btnReprovados.Size = new Size(100, 29);
            btnReprovados.TabIndex = 3;
            btnReprovados.Text = "Reprovados";
            btnReprovados.UseVisualStyleBackColor = true;
            btnReprovados.Visible = false;
            btnReprovados.Click += btnReprovados_Click;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(6, 6);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(100, 29);
            btnAtualizar.TabIndex = 1;
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // lblRelatorio
            // 
            lblRelatorio.AutoSize = true;
            lblRelatorio.Location = new Point(8, 73);
            lblRelatorio.Name = "lblRelatorio";
            lblRelatorio.Size = new Size(0, 20);
            lblRelatorio.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(btn_Importar);
            tabPage3.Controls.Add(btn_Procurar);
            tabPage3.Controls.Add(txt_Caminho);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(931, 572);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Importar";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 6);
            label1.Name = "label1";
            label1.Size = new Size(258, 20);
            label1.TabIndex = 3;
            label1.Text = "Selecione o arquivo para importação:";
            // 
            // btn_Importar
            // 
            btn_Importar.Location = new Point(106, 67);
            btn_Importar.Name = "btn_Importar";
            btn_Importar.Size = new Size(94, 29);
            btn_Importar.TabIndex = 2;
            btn_Importar.Text = "Importar";
            btn_Importar.UseVisualStyleBackColor = true;
            btn_Importar.Click += btn_Importar_Click_1;
            // 
            // btn_Procurar
            // 
            btn_Procurar.Location = new Point(6, 67);
            btn_Procurar.Name = "btn_Procurar";
            btn_Procurar.Size = new Size(94, 29);
            btn_Procurar.TabIndex = 1;
            btn_Procurar.Text = "Procurar";
            btn_Procurar.UseVisualStyleBackColor = true;
            btn_Procurar.Click += btn_Procurar_Click_1;
            // 
            // txt_Caminho
            // 
            txt_Caminho.Location = new Point(3, 34);
            txt_Caminho.Name = "txt_Caminho";
            txt_Caminho.PlaceholderText = "Caminho do arquivo";
            txt_Caminho.Size = new Size(425, 27);
            txt_Caminho.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 605);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Cadastro de Alunos";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBoxCadastro.ResumeLayout(false);
            groupBoxCadastro.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label lbl_ContagemAlunos;
        private ListBox listBoxAlunos;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private GroupBox groupBoxCadastro;
        private TextBox txtNota;
        private TextBox txtMatricula;
        private TextBox txtCurso;
        private TextBox txtIdade;
        private TextBox txtNome;
        private TextBox txtPesquisaMatricula;
        private TextBox txtPesquisaNome;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnPesquisar;
        private Button btnVerificarAprovacao;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnNovoAluno;
        private Button btnAtualizar;
        private Label lblRelatorio;
        private Button btn_Importar;
        private Button btn_Procurar;
        private TextBox txt_Caminho;
        private Label label1;
        private Button btnAprovados;
        private Button btnReprovados;
        private ListBox listBoxAR;
        private Button btnDownload;
    }
}
