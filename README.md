# AppEvolucional
Projeto de Teste para Evolucional

Adriano (adriano.emidio0@gmail.com)

* Aviso Legal: Este programa é apenas uma demostração e seu uso é autorizado para qualquer finalidade, desde que obedecidos os regimentos da lei. O Autor não se resposabiliza por nenhum dano ou perca de dados causados ao usuário ou à terceiros decorrente do uso deste software. 

O software foi testado utilizando as seguintes configurações de software:
* SO: Manjaro Linux 5.8.18-1 x86_64
* Dot Net Core 3.1.108
* Microsoft SQL Server 2019 (RTM-CU5) (KB4552255) - 15.0.4043.16 Developer Edition (64-bit) on Linux

Caso haja qualquer problema em configurar a aplicação em outras configuração de software, sinta-se a vontade de me contatar por e-mail.


* Sobre a solução

Antes de iniciar o aplicativo, deve-se configurar o banco de dados, para isso adicione no arquivo "appsettings.json" :

"DefaultConnection" : "Data Source=endereçoDB;Initial Catalog=projeto-evolucional;User ID=usuario;Password=senha;"

O projeto foi pensado em uma solução "Code first", ou seja, para se inicilizar o banco de dados, deve se excutar o migration, apos a adicção da string de conexão conforme a seguir:

<p>$dotnet-ef migrations add minhaMigration</p>
<p>$dotnet-ef database update</p>
