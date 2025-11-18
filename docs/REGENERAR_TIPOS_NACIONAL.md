# Como Regenerar Tipos do Padrão Nacional v101

Este documento descreve como regenerar os tipos C# a partir dos schemas XSD do padrão Nacional v101.

## Status Atual

✅ **Tipos já foram gerados com sucesso!**

- **Data da geração**: $(date)
- **Ferramenta utilizada**: dotnet-xscgen v3.0.1188.0
- **Arquivos gerados**: 241 arquivos em `src/Abrasf.Core/Models/NacionalTypesGenerated/`
- **Schemas corrigidos**: `simpleTypes.xsd` e `schema_v101.xsd` (removido maxLength duplicado em TSCPF)

## Pré-requisitos

- .NET SDK instalado
- Acesso aos schemas XSD em `src/Abrasf.Web/Schemas/nacional/`

## Método 1: Usando xsd.exe (Windows)

```bash
# Navegar até a pasta de schemas
cd "src/Abrasf.Web/Schemas/nacional"

# Gerar tipos do schema principal
xsd.exe schema_v101.xsd /c /n:Abrasf.Core.Models /o:../../../Abrasf.Core/Models

# Ou gerar tipos de schemas específicos
xsd.exe simpleTypes.xsd complexTypes.xsd enviarLoteDps.xsd /c /n:Abrasf.Core.Models /o:../../../Abrasf.Core/Models
```

## Método 2: Usando svcutil.exe (Windows)

```bash
# Gerar tipos e contratos de serviço
svcutil.exe schema_v101.xsd /dconly /n:*,Abrasf.Core.Models /o:NacionalTypes.cs
```

## Método 3: Usando dotnet-xscgen (Cross-platform)

```bash
# Instalar a ferramenta
dotnet tool install -g dotnet-xscgen

# Gerar tipos
xscgen -n "http://www.sped.fazenda.gov.br/nfse=Abrasf.Core.Models" schema_v101.xsd -o NacionalTypes.cs
```

## Método 4: Usando xsd2code (Visual Studio Extension)

1. Instalar a extensão "xsd2code++" no Visual Studio
2. Clicar com botão direito no arquivo `schema_v101.xsd`
3. Selecionar "xsd2code++" > "Generate Code"
4. Configurar namespace: `Abrasf.Core.Models`
5. Configurar output: `src/Abrasf.Core/Models/NacionalTypes.cs`

## Tipos que Precisam ser Regenerados

### Tipos de Envio (Envio)
- `EnviarLoteDpsEnvio` ✓ (criado temporariamente)
- `EnviarLoteDpsSincronoEnvio` ✓ (criado temporariamente)
- `ConsultarNfseDpsEnvio` ✓ (criado temporariamente)
- `ConsultarDpsDisponivelEnvio` ✓ (criado temporariamente)
- `ConsultarLoteDpsEnvio` (já existe como ConsultarLoteRpsEnvio - precisa atualizar namespace)

### Tipos de Resposta (Resposta)
- `EnviarLoteDpsResposta` ✓ (criado como EnviarLoteDpsResponse)
- `EnviarLoteDpsSincronoResposta` ✓ (criado como EnviarLoteDpsSincronoResposta)
- `ConsultarNfseDpsResposta` ✓ (criado como ConsultarNfseDpsResposta)
- `ConsultarDpsDisponivelResposta` ✓ (criado como ConsultarDpsDisponivelResposta)
- `ConsultarLoteDpsResposta` ✓ (criado como ConsultarLoteDpsResposta)

### Tipos Complexos
- `tcLoteDps` ✓ (criado temporariamente)
- `tcIdentificacaoDps` ✓ (criado temporariamente)
- `TCDPS` ✓ (criado temporariamente)
- `TCInfDPS` ✓ (criado temporariamente - versão simplificada)
- `tcIdentificacaoPessoaEmpresa` (já existe - pode ser reutilizado)
- `SignatureType` (já existe - pode ser reutilizado)

## Namespace Importante

Todos os tipos do padrão nacional devem usar o namespace:
```
http://www.sped.fazenda.gov.br/nfse
```

Ao invés do namespace ABRASF:
```
http://www.abrasf.org.br/nfse.xsd
```

## Arquivos Temporários Criados

Os seguintes arquivos foram criados temporariamente e devem ser substituídos pelos tipos regenerados:

1. `src/Abrasf.Core/Models/NacionalTypes.cs` - Tipos de envio e tipos complexos básicos
2. `src/Abrasf.Core/Models/Response/EnviarLoteDpsResponse.cs` - Response simplificado
3. `src/Abrasf.Core/Models/Response/EnviarLoteDpsSincronoResponse.cs` - Response simplificado
4. `src/Abrasf.Core/Models/Response/ConsultarLoteDpsResponse.cs` - Response simplificado
5. `src/Abrasf.Core/Models/Response/ConsultarNfseDpsResponse.cs` - Response simplificado
6. `src/Abrasf.Core/Models/Response/ConsultarDpsDisponivelResponse.cs` - Response simplificado

## Após Regenerar os Tipos

1. Substituir os arquivos temporários pelos tipos regenerados
2. Verificar se todos os namespaces estão corretos
3. Atualizar referências nos handlers se necessário
4. Testar a deserialização XML com exemplos reais do padrão nacional
5. Verificar compatibilidade com os repositórios

## Notas Importantes

- Os tipos temporários criados são versões simplificadas que funcionam para deserialização básica
- O tipo `TCInfDPS` é especialmente complexo e deve ser regenerado completamente do schema
- Alguns tipos podem precisar de ajustes manuais após a geração automática
- Teste sempre com XMLs reais do padrão nacional após regenerar os tipos

