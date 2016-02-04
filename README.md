# Minha Net Minha Vida (MNMV)

Minha Net Minha Vida é um sistema automatizado de testes na velocidade da conexão que foi baseado na idéia do usuário [AlekseyP](https://www.reddit.com/user/AlekseyP) que postou no [reddit](https://www.reddit.com/r/technology/comments/43fi39/i_set_up_my_raspberry_pi_to_automatically_tweet/) seu programa que enviava tweet para a Comcast todas as vezes que sua velocidade era baixa.

# Configuração
Para usar o MNMV você precisa seguir alguns passos.

1. Acesse o [Twitter Apps](https://apps.twitter.com/) e clique no botão **Create New App**.
2. No campo **Name**, digite o nome qualquer como por exemplo: MinhaNetMinhaVida.
3. No campo **Description**, digite uma descrição qualquer como por exemplo: Meu aplicativo.
4. No campo **Website**, digite uma URL qualquer como por exemplo: [https://github.com/erycson/MinhaNetMinhaVida].
5. Leia o **Developer Agreement** e depoi marque a opção **Yes, I agree**.
6. Crie sua aplicação clicando em **Create your Twitter application**.

Depois de ter criado sua aplicação você deve pegar algumas informações necessárias para usar no MNMV.

1. Na tela aberta após criar sua aplicação, clique na aba **Keys and Access Tokens**.
2. Já na aba clique em **Create my access token**.

Com as informações necesárias já geradas agora vamos configurar o MNMV.

1. Abra o arquivo **MinhaNetMinhaVida.exe**
2. Clique em com o botão direito do mouse no MNMV que estará nos ícones da área notificação.
3. Clique em **Configurações**.
4. Na janela aberta coloque as informações do Twitter, suas configurações e o twitter da sua prestadora de internet.
5. Depois clique em **Salvar e Fechar**
6. Novamente clique em com o botão direito do mouse no MNMV e depois clique em **Inciar**

Pronto, apartir daqui o MNMV ficará restando sua internet automaticamente e publicará um tweet cada vez que sua internet estiver lenta.
Obs.: As opções **Velocidade Média** e **Velocidade Mínima** estão configuradas para seguir a [Resolução nº 574, de 28 de outubro de 2011](http://www.anatel.gov.br/legislacao/resolucoes/26-2011/57-resolucao-574) da Anatel.