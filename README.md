# Ludumdare

- Já que no github não permite salvar pastas em branco, adicionei um shell script caso seja necessário ter algum(s) diretório(s) em branco no repositório. Só lembrar de rodar o `create-gitkeep.sh` antes de mandar as alterações.


- Ps: caso Alguém não conheça o como usar o git, só me falar que eu colocarei os passos básicos aqui!



# Passos para configuração do ambiente usanod git

- 1. Criar a sua conta no github : `https://github.com/`
- 2. Baixar o Git Bash `https://git-scm.com/downloads` 
- 3. No git bash, usar o comando `ssh-keygen` para gerar a chave.
- 3.1 Usar o comando `cat ~/.ssh/id_rsa.pub` para ler a chave ou alternativamente abrir o arquivo e copiar a chave manualmente.
- 4  Em `Settings -> SSH Keys` addicionar a chave gerada anteriormente.
- 5. No git bash e na pasta onde será a workspace do jogo,
- 6. Crie um fork do projeto principal `https://github.com/johnnytn/ludumdare`
- 7. Clonar o seu fork `git clone git@github.com:XX/ludumdare.git`
- 8. Adicionar o alias pro para o projeto principal `git remote add upstream git@github.com:johnnytn/ludumdare.git`


A partir daqui o workspace estará configurado, agora é só começar!

# Trabalhando com o Git

Após adicionar o repositório, para toda nova alteraração que for realizada e será enviada pro github no final é precisará fazer 3 passos: 
- 1. git add arquivo ou *(adiciona tudo) ou *.extensão -> adiciona os arquivos que serão enviados.
- 2, git commit -m" mensagem " -> realiza o commit e escreve a mensagem dele.
- 3, git push -> envia as alterações.

Ps: Sempre lembrar de dar `git fetch` e `git rebase` antes de realizar qualquer push para o master, para sempre ter o master sincornizado e sem conflitos.




