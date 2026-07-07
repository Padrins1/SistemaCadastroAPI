# 📋 SistemaCadastroAPI

API REST de cadastro de funcionários desenvolvida em C# com ASP.NET Core e Entity Framework.

---

## ⚙️ Funcionalidades

- ✅ Cadastrar funcionário
- ✅ Listar todos os funcionários
- ✅ Buscar funcionário por ID
- ✅ Atualizar funcionário
- ✅ Remover funcionário

---

## 🛠️ Tecnologias

- C# / .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

---

## 🚀 Como rodar

1. Clone o repositório
```bash
git clone https://github.com/Padrins1/SistemaCadastroAPI.git
```
2. Abra no Visual Studio
3. Configure a connection string no `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=SistemaCadastroDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```
4. Rode as migrations:
```
Update-Database
```
5. Inicie com `F5` e acesse o Swagger em `https://localhost:{porta}/swagger`

---

## 📡 Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET | /api/Funcionario | Lista todos |
| GET | /api/Funcionario/{id} | Busca por ID |
| POST | /api/Funcionario | Cadastra novo |
| PUT | /api/Funcionario/{id} | Atualiza |
| DELETE | /api/Funcionario/{id} | Remove |

---

*Projeto desenvolvido durante estudos de C# e ASP.NET Core — parte do meu portfólio de evolução como dev.*
