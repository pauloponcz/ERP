# ComodoroERP

Sistema desktop em Windows Forms para gerenciamento de orçamentos da Comodoro Serviços.

Esta versão permite cadastrar orçamentos, controlar serviços permitidos, editar itens, gerar notas em PDF a partir de modelos Excel personalizados, configurar pastas de saída e manter backup automático do banco SQLite.

---

## 1. Visão geral

O ComodoroERP é um sistema local desenvolvido em C# Windows Forms com banco SQLite.

O sistema foi criado para facilitar o controle de:

- Clientes/escolas;
- Orçamentos;
- Itens de serviço;
- Serviços permitidos;
- Status dos orçamentos;
- Geração de notas;
- Geração de PDFs;
- Backup do banco de dados;
- Configuração de pastas;
- Dashboard de acompanhamento.

---

## 2. Tecnologias utilizadas

- C#
- Windows Forms
- .NET 9
- SQLite
- Microsoft.Data.Sqlite
- QuestPDF
- ClosedXML
- Microsoft Excel via late binding
- Git/GitHub

---

## 3. Estrutura principal do projeto

```text
ERP
├── ComodoroERP
│   ├── Data
│   │   └── Database.cs
│   ├── Models
│   │   ├── Cliente.cs
│   │   ├── Orcamento.cs
│   │   ├── OrcamentoItem.cs
│   │   └── ServicoPermitido.cs
│   ├── Services
│   │   ├── BackupService.cs
│   │   ├── ConfiguracaoService.cs
│   │   ├── DashboardService.cs
│   │   ├── OrcamentoService.cs
│   │   └── ServicoPermitidoService.cs
│   ├── Reports
│   │   ├── PdfService.cs
│   │   ├── ExcelNotaService.cs
│   │   └── ExcelModeloPdfService.cs
│   ├── FrmMenu.cs
│   ├── FrmNovoOrcamento.cs
│   ├── FrmOrcamentos.cs
│   ├── FrmDetalhesOrcamento.cs
│   ├── FrmEditarOrcamento.cs
│   ├── FrmAdicionarItemOrcamento.cs
│   ├── FrmEditarItemOrcamento.cs
│   ├── FrmItens.cs
│   ├── FrmServicosPermitidos.cs
│   ├── FrmConfiguracoes.cs
│   └── FrmDashboard.cs
├── .gitignore
└── ERP.slnx
```

---

## 4. Banco de dados

O sistema usa SQLite.

As principais tabelas são:

### Clientes

Guarda os dados do cliente/escola.

Campos principais:

- Id
- Nome
- Cnpj
- Endereco
- BairroCep
- CidadeEstado

### Orcamentos

Guarda o cabeçalho do orçamento.

Campos principais:

- Id
- ClienteId
- Titulo
- DataOrcamento
- Status
- VariacaoNota2
- VariacaoNota3
- Observacao
- DataCriacao

### OrcamentoItens

Guarda os serviços lançados em cada orçamento.

Campos principais:

- Id
- OrcamentoId
- Categoria
- ServicoPermitido
- DescricaoOrcamento
- Quantidade
- ValorUnitario
- Cortesia
- ValorTotal
- Observacao

### ServicosPermitidos

Guarda a lista oficial de serviços que podem ser usados nos orçamentos.

Campos principais:

- Id
- Categoria
- Descricao
- Ativo

### NotasGeradas

Guarda informações sobre PDFs/notas geradas.

Campos principais:

- Id
- OrcamentoId
- NumeroNota
- PercentualVariacao
- ValorTotal
- CaminhoPdf
- DataGeracao

### Configuracoes

Guarda configurações do sistema.

Exemplos:

- PastaPdfs
- PastaBackups
- ModeloNotas

---

## 5. Funcionalidades da versão atual

## 5.1 Menu principal

Tela inicial do sistema.

A partir dela é possível acessar:

- Dashboard;
- Novo Orçamento;
- Ver Orçamentos;
- Itens Lançados;
- Serviços Permitidos;
- Configurações;
- Sair.

---

## 5.2 Dashboard

Tela de resumo geral.

Mostra:

- Total de orçamentos;
- Quantidade de pendentes;
- Quantidade de pagos;
- Quantidade de cancelados;
- Valor total;
- Valor pendente;
- Valor pago;
- Últimos orçamentos cadastrados.

Essa tela usa o `DashboardService`.

---

## 5.3 Serviços Permitidos

Tela responsável por controlar os serviços que podem ser utilizados nos orçamentos.

Funcionalidades:

- Importar CSV com serviços permitidos;
- Listar serviços por categoria;
- Filtrar por categoria;
- Filtrar por descrição do serviço.

Formato esperado do CSV:

```csv
Categoria;Descricao
SERVIÇO DE MANUTENÇÃO ELÉTRICA;INSTALAÇÃO DE LUMINÁRIA
SERVIÇO DE MANUTENÇÃO HIDRÁULICA;REPARO DE REDE HIDRÁULICA
```

Ao importar, o sistema ignora serviços duplicados.

---

## 5.4 Novo Orçamento

Tela para cadastrar um orçamento completo.

Permite informar:

- Cliente;
- CNPJ;
- Endereço;
- Bairro/CEP;
- Cidade/Estado;
- Título;
- Data;
- Status;
- Variação da Nota 2;
- Variação da Nota 3;
- Observação;
- Itens do orçamento.

Os serviços disponíveis são carregados da tabela `ServicosPermitidos`.

Fluxo:

1. Seleciona categoria;
2. Seleciona serviço permitido;
3. Digita a descrição que aparecerá no orçamento;
4. Informa quantidade;
5. Informa valor unitário;
6. Marca cortesia, se necessário;
7. Adiciona o item;
8. Salva o orçamento.

---

## 5.5 Ver Orçamentos

Tela para consultar orçamentos cadastrados.

Filtros disponíveis:

- Cliente;
- Status;
- Data inicial;
- Data final.

Ações disponíveis:

- Abrir orçamento;
- Alterar status;
- Gerar notas/PDFs;
- Excluir orçamento;
- Fechar.

A exclusão remove:

- Orçamento;
- Itens vinculados;
- Notas geradas;
- PDFs gerados, quando localizados.

---

## 5.6 Detalhes do Orçamento

Tela para visualizar um orçamento completo.

Mostra:

- Dados do cliente;
- Dados do orçamento;
- Status;
- Valores das notas;
- Itens lançados;
- Botões de ação.

Ações disponíveis:

- Editar orçamento;
- Adicionar item;
- Editar item;
- Remover item;
- Gerar PDFs;
- Abrir pasta de PDFs;
- Fechar.

---

## 5.7 Editar Orçamento

Permite alterar dados principais do orçamento:

- Título;
- Status;
- Variação da Nota 2;
- Variação da Nota 3;
- Observação.

Nesta versão, a edição de cliente é separada da edição de orçamento.

---

## 5.8 Adicionar Item ao Orçamento

Permite adicionar um novo item em um orçamento já existente.

Campos:

- Categoria;
- Serviço permitido;
- Descrição;
- Quantidade;
- Valor unitário;
- Cortesia;
- Observação.

Ao salvar, os totais do orçamento são atualizados automaticamente.

---

## 5.9 Editar Item do Orçamento

Permite editar um item existente.

Campos editáveis:

- Categoria;
- Serviço permitido;
- Descrição;
- Quantidade;
- Valor unitário;
- Cortesia;
- Observação.

Ao salvar, o valor total do item é recalculado.

---

## 5.10 Remover Item

Permite remover um item selecionado no orçamento.

Antes de remover, o sistema solicita confirmação.

---

## 5.11 Itens Lançados

Tela para consultar todos os itens cadastrados nos orçamentos.

Filtros disponíveis:

- Cliente;
- Categoria;
- Serviço;
- Status;
- Data inicial;
- Data final.

Essa tela ajuda a consultar rapidamente todos os serviços lançados no sistema.

---

## 5.12 Configurações

Tela para definir caminhos usados pelo sistema.

Configurações atuais:

- Pasta dos PDFs;
- Pasta dos backups;
- Modelo de notas em Excel.

Essas informações são salvas na tabela `Configuracoes`.

---

## 5.13 Backup automático

Ao abrir o sistema, o `BackupService` cria backup do banco SQLite.

O backup é salvo na pasta configurada pelo usuário.

Regra atual:

- Gera um backup por dia;
- Se já existir backup do dia, não gera outro.

Exemplo de nome:

```text
comodoro_backup_20260813.db
```

---

## 6. Geração de notas por modelo Excel

A versão atual permite gerar PDFs a partir de um arquivo Excel usado como modelo.

O usuário escolhe um arquivo `.xlsx` em:

```text
Menu > Configurações > Modelo de Notas
```

Esse arquivo pode conter uma ou mais abas.

Cada aba vira um PDF.

Exemplos de abas:

```text
NOTA_1
NOTA_2
NOTA_3
MODELO_EXTRA
```

Se a aba tiver número no nome, o sistema usa esse número para aplicar a variação correspondente.

Exemplos:

- `NOTA_1` usa variação 0%;
- `NOTA_2` usa `VariacaoNota2`;
- `NOTA_3` usa `VariacaoNota3`;
- Aba sem número assume nota 1.

---

## 7. Placeholders disponíveis no modelo Excel

Os campos dinâmicos devem ser escritos entre chaves `{}`.

Exemplo:

```text
{cliente}
{cnpj}
{valor_total}
```

Se o campo não existir, o sistema substitui por vazio.

---

## 7.1 Campos do cabeçalho

Campos disponíveis:

```text
{orcamento_id}
{nota_numero}
{cliente}
{cnpj}
{endereco}
{bairro_cep}
{cidade_estado}
{data_orcamento}
{titulo}
{status}
{observacao}
{variacao_percentual}
{valor_total}
{valor_total_numero}
```

Exemplo no Excel:

```text
CLIENTE: {cliente}
CNPJ: {cnpj}
DATA: {data_orcamento}
TOTAL DEVIDO: {valor_total}
```

---

## 7.2 Campos dos itens

Campos disponíveis:

```text
{item_categoria}
{item_servico_permitido}
{item_descricao}
{item_quantidade}
{item_valor_unitario}
{item_valor_total}
{item_observacao}
{item_cortesia}
```

Exemplo no Excel:

```text
A10: {item_descricao}
B10: {item_quantidade}
C10: {item_valor_unitario}
D10: {item_valor_total}
```

A linha que contém algum campo iniciado por `{item_` é usada como linha modelo.

Se o orçamento tiver vários itens, o sistema copia essa linha e preenche os itens.

---

## 8. Como montar um modelo Excel

Exemplo simples de aba:

```text
A1: COMODORO SERVIÇOS
A2: ORÇAMENTO: {orcamento_id}
A3: NOTA: {nota_numero}
A4: CLIENTE: {cliente}
A5: CNPJ: {cnpj}
A6: ENDEREÇO: {endereco}
A7: DATA: {data_orcamento}
A8: TÍTULO: {titulo}

A10: DESCRIÇÃO
B10: QTD
C10: VALOR UNIT.
D10: TOTAL

A11: {item_descricao}
B11: {item_quantidade}
C11: {item_valor_unitario}
D11: {item_valor_total}

C15: TOTAL:
D15: {valor_total}
```

Nesse exemplo, a linha 11 será repetida para todos os itens do orçamento.

---

## 9. Recomendações para o modelo Excel

Pode usar:

- Logos como imagem inserida no Excel;
- Bordas;
- Cores;
- Fontes;
- Células mescladas;
- Largura de colunas;
- Altura de linhas;
- Área de impressão;
- Cabeçalho e rodapé;
- Várias abas.

Evite colocar placeholders dentro de:

- Fórmulas;
- Caixas de texto;
- Formas;
- Imagens;
- Objetos flutuantes.

Os placeholders devem ficar em células normais.

---

## 10. Geração dos PDFs

O sistema usa o Excel instalado na máquina para exportar os PDFs.

Fluxo:

```text
Modelo Excel configurado
↓
Sistema copia o modelo para arquivo temporário
↓
Preenche os placeholders
↓
Exporta cada aba como PDF
↓
Salva os PDFs na pasta configurada
↓
Remove o arquivo temporário
```

Os PDFs são gerados em:

```text
Configurações > Pasta dos PDFs
```

Exemplo:

```text
C:\ComodoroERP\pdfs
```

Exemplo de arquivo gerado:

```text
Orcamento_001_Nota_1_NOTA_1_CMEI_EXEMPLO.pdf
```

---

## 11. Requisito para geração por Excel

Para gerar PDFs por modelo Excel, a máquina precisa ter o Microsoft Excel instalado.

O sistema utiliza:

```text
Excel.Application
```

via late binding.

Com isso, o sistema não depende diretamente das DLLs `Microsoft.Office.Interop.Excel` e `office.dll`.

---

## 12. Observações importantes

### Banco SQLite

O banco atual é criado automaticamente pelo sistema.

Se as pastas `bin` e `obj` forem apagadas, o banco pode ser perdido caso esteja dentro da pasta de execução.

Por isso, é recomendado manter backup externo configurado.

### Backup

Sempre configure uma pasta externa de backup, por exemplo:

```text
C:\ComodoroERP\backups
```

### PDFs

Configure também uma pasta externa para PDFs, por exemplo:

```text
C:\ComodoroERP\pdfs
```

### Modelos

O modelo Excel pode ficar em uma pasta fixa, por exemplo:

```text
C:\ComodoroERP\modelos\modelo_notas.xlsx
```

---

## 13. Status atual da versão

Esta versão possui:

- Cadastro de orçamentos;
- Cadastro de itens;
- Edição de orçamento;
- Edição de itens;
- Remoção de itens;
- Exclusão de orçamento;
- Serviços permitidos via CSV;
- Dashboard;
- Filtros por cliente/status/data;
- Configuração de pastas;
- Backup automático;
- Geração de PDFs por modelo Excel;
- Suporte a múltiplas abas/modelos no Excel;
- Placeholders dinâmicos;
- Ignora campos inexistentes.
