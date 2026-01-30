# Nota Nacional

Aplicação ASP.NET Core para serviços de NFS-e (Nota Fiscal de Serviços Eletrônica) Nacional.

## Requisitos

- .NET 9.0 SDK ou superior
- Certificado de desenvolvimento HTTPS do .NET (será configurado automaticamente)

## Configuração do Certificado HTTPS para Desenvolvimento

Antes de executar a aplicação, é necessário configurar o certificado de desenvolvimento HTTPS:

### Verificar se o certificado existe

```bash
dotnet dev-certs https --check
```

### Instalar e confiar no certificado

```bash
dotnet dev-certs https --trust
```

**Nota para macOS:** Este comando pode solicitar sua senha para instalar o certificado no keychain do sistema.

## Executando a Aplicação

### 1. Navegue até o diretório do projeto web

```bash
cd src/NotaNacional.Web
```

### 2. Restaure as dependências (se necessário)

```bash
dotnet restore
```

### 3. Execute a aplicação

```bash
dotnet run
```

Ou usando o Visual Studio Code / Rider, simplesmente execute o projeto com o perfil "NotaNacional.Web".

## URLs da Aplicação

Após iniciar a aplicação, ela estará disponível em:

- **HTTPS (Principal):** `https://localhost:5246`
- **HTTP (Redireciona para HTTPS):** `http://localhost:5245`

### Endpoints Disponíveis

- **Serviço SOAP:** `https://localhost:5246/Nfse.asmx`
- **Páginas Razor:** `https://localhost:5246`

## Configuração

### Arquivos de Configuração

- `appsettings.json` - Configurações gerais
- `appsettings.Development.json` - Configurações específicas para desenvolvimento
- `appsettings.Production.json` - Configurações específicas para produção

### Variáveis de Ambiente

A aplicação usa `ASPNETCORE_ENVIRONMENT` para determinar o ambiente:
- `Development` - Ambiente de desenvolvimento (padrão ao executar localmente)
- `Production` - Ambiente de produção

## Estrutura do Projeto

```
src/
├── NotaNacional.Web/          # Aplicação web ASP.NET Core
├── NotaNacional.Core/          # Lógica de negócio e modelos
├── NotaNacional.Infra/         # Infraestrutura e repositórios
└── NotaNacional.ServiceProcess/ # Processo de serviço Windows
```

## Segurança HTTPS

A aplicação está configurada para:

- Redirecionar automaticamente requisições HTTP para HTTPS
- Usar HSTS (HTTP Strict Transport Security) em produção
- Utilizar certificado de desenvolvimento para localhost

**Importante:** O certificado de desenvolvimento é válido apenas para `localhost` e `127.0.0.1`. Em produção, configure um certificado válido no servidor.

## Solução de Problemas

### Certificado não confiável

Se o navegador mostrar um aviso sobre o certificado não ser confiável:

1. Execute novamente: `dotnet dev-certs https --trust`
2. No macOS, verifique se o certificado está no keychain do sistema
3. Aceite o certificado no navegador para desenvolvimento local

### Porta já em uso

Se as portas 5245 ou 5246 estiverem em uso, você pode alterá-las em:
- `src/NotaNacional.Web/Properties/launchSettings.json`

### Erro ao iniciar com HTTPS

Certifique-se de que o certificado de desenvolvimento está instalado e confiável:

```bash
dotnet dev-certs https --check --trust
```

## Desenvolvimento

### Build

```bash
dotnet build
```

### Testes

Execute os testes do projeto (se houver):

```bash
dotnet test
```

## Licença

Nota Control Tecnologia
