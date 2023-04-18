# **Entity Framework Anotações**
## Transferindo API "Course" do curso de Spring + Angular da Loiane Groner, de Java Spring para  API ASP NET Core com Entity Framework

- Nesse exemplo estou usando o SQLite inicialmente para fazer os pequenos testes.

- Para adicionar uma Migration
No Visual Studio (2019), ir em "View/Other Windows/Package Manager Console". 
Digitar "get-help entityframeworkcore" > Vai mostrar alguns comandos do Entity.
Digitar o comando "Add-Migration <nome da sua migration>". É esperado que crie a Migration. Verificar no seu "Solution Explorer" se realmente criou.

- Para criar / atualizar sua base de dados

No console aberto digitar "update-database". Esperado que crie os arquivos de banco de dados no "Solution Explorer"
