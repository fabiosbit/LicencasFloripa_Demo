# LicençasFloripa - DEMO

Meu primeiro aplicativo para uso em produção numa empresa real **(está sento utilizado dês de 19/09/2019)**. Desenvolvi enquanto estava aprendendo a linguagem, depois de pronto fiz algumas refatorações para reduzir a quantidade de código repetido e comecei a implementar o padrão de projeto MVVM, mas ainda existe partes que podem ser melhoradas, principalmente a lógica que está no arquivo "PesquisaLicenças.xaml.cs" e deveria ir para a pasta Models.

Desenvolvido em C#, WPF e SQL Server **(meu primeiro contato com as três tecnologias).**

Demo do aplicativo de gerenciamento de licenças feito para a Floripa Tecnologia.

Versão modificada para utilizar um banco de dados de teste e com gerador de licenças removido.

A pasta **"SQL Procedures"** contém todos os procedimentos criados no SQL Server.


## Abaixo as notas das versões:

**1.0.0.0:** <br>
Primeira versão de teste. <br>

**1.1.0.0:** <br>
Primeira versão de produção. <br>
Adicionado botões para selecionar o tipo de licença; <br>
Renomeado alguns itens para melhor entendimento; <br>
Corrigido a posição do botão "cadastrar". <br>

**1.2.0.0:** <br>
Adicionado status da garantia em "pesquisar e alterar" licenças; <br>
DataGrid alterado para somente leitura e seleção por célula. <br>

**2.0.0.0:** <br>
Adicionado menu "Contratos de Suporte" para pesquisar e cadastrar contratos; <br>
Adicionado status de suporte Premium em "pesquisar e alterar" licenças; <br>
Adicionado botão para executar o FloripaSec; <br>
Itens do menu renomeados para melhor entendimento; <br>
Corrigido bug quando a primeira pesquisa não retorna nenhum valor; <br>
Diminuido tamanho da fonte e da janela para caber em 1440x900 e zoom 125%. <br>

**2.1.0.0:** <br>
Adicionada a opção de escolher qual a versão do FloripaSec será executada.

**2.2.0.0:** <br>
Ao cadastrar ou atualizar um suporte premium, é gerado um arquivo xlsx no servidor com 
o conteúdo de toda a tabela Premium e sincronizado com o google drive do suporte;  <br>
Ao dar duplo clique em alguma linha do grid Busca Geral, a contra senha da linha é enviada para
o menu "Pesquisar e Alterar".

**2.3.0.0:** <br>
Adicionado botões para selecionar o tipo de negócio (venda, demo, aluguel ou feira) no cadastro de licenças; <br>
Informa que está na garantia e é premium quando equipamanto for demo, aluguel ou feira; <br>
Melhorias no design (cores e fontes); <br>

**2.3.1.0:** <br>
Menu Pesquisar Licenças e Pesquisar Premium agora iniciam sem exibir os itens na tela, evitando
que o usuário tente pesquisar pelos campos; <br>

**2.3.2.0:** <br>
Consultas SQL feitas em comando C# agora são feitas via Stored Procedures; <br>
Exibe o botão de Salvar Alteração nos menus de pesquisa só depois que algo for pesquisado; <br>
Corrigido problema com as datas quando o sistema operacional está em outro idioma ou formato de data; <br>
Criado novas caixas de mensagens no mesmo design do programa. <br>

**2.3.3.0:** <br>
Alterado o código de exibição das janelas (views); <br>
Ao dar duplo clique em alguma linha do Grid Busca Geral, a janela muda para o menu Pesquisar Licenças
já exibindo o resultado da busca. <br>

**3.0.0.0:** <br>
Novo menu "Financeiro" para cadastrar os clientes que estão com pendências financeiras e os equipamentos
que devem ter o suporte e licenças suspensos. Adicionado também o menu de pesquisa de SNs por código de cliente ou
CNPJ ou Nota Fiscal; <br>
Adicionado informativo quando o suporte e as parciais devem ser suspensos no menu "Pesquisar e Alterar" Licenças; <br>
Adicionado opção de suspender suporte premium no menu "Pesquisar e Alterar" do "Contratos de Suporte"; <br>
Ao dar duplo clique em alguma linha do grid Busca Geral Premium, a janela muda para o menu de edição daquela linha; <br>
Alterado o título e a ordem das caixas de texto dos menus Cadastro e Pesquisa de licenças para ficar igual ao FloripaSec; <br>
Botões do menu principal renomeados para maior clareza; <br>
Altura mínima da janela foi aumentada para ter mais espaço entre os botão de tipo de negócio no cadastro de licença; <br>
Otimizado a lógica e feito um novo SqlProcedure para verificar os status de garantia, suporte e pagamento; <br>
Removido os horários zerados nas buscas gerais quando o botão de pesquisa é utilizado (ainda aparece os zeros na primeira listagem); <br>
Agora apenas um menu principal fica expandido, os outros recolhem ao clicar em outro menu. <br>

**3.1.0.0:** <br>
Adicionado o campo DataLicença na pesquisa de licenças, agora exibe a data de cadastro e a data que foi gerada a licença; <br>
Adicionado a Data que o registro foi inserido na lista de Pendências. <br>

**3.1.1.0:** <br>
Alterado a forma de geração das colunas dos DataGrids de automático para manual; <br>
Corrigido a formatação das datas nos DataGrids, agora nunca irá aparecer os zeros. <br>

**3.2.0.0:** <br>
Adicionado botão para excluir contrato Premium; <br>
Adicionado nome fantasia do cliente na busca e cadastro de devedores; <br>
Alterado para exportar para o XML somente os contratos Premium ativos. <br>

**4.0.0.0:** <br>
Criado novo menu "Pesquisa Microsiga" com as opções de pesquisar Clientes e Produtos do Cliente na base de dados da TOTVS.

