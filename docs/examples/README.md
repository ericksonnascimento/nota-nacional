# Exemplos de XML para NFS-e Nacional

Este diretório contém exemplos de XML para cada operação do webservice NFS-e Nacional, conforme definido no padrão ABRASF v1.01.

## Estrutura dos Arquivos

Cada operação possui dois arquivos:
- `{Operacao}-nfseCabecMsg.xml`: Conteúdo que deve ser inserido no elemento `nfseCabecMsg`
- `{Operacao}-nfseDadosMsg.xml`: Conteúdo que deve ser inserido no elemento `nfseDadosMsg`

## Operações Disponíveis

### 1. CancelarNfse
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `CancelarNfseEnvio` com dados do pedido de cancelamento

### 2. ConsultarDadosCadastrais
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarDadosCadastraisEnvio` com identificação do prestador

### 3. ConsultarDpsDisponivel
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarDpsDisponivelEnvio` com prestador e opcionalmente identificação do DPS

### 4. ConsultarLoteDps
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarLoteDpsEnvio` com prestador e protocolo do lote

### 5. ConsultarNfseDps
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarNfseDpsEnvio` com identificação do DPS e prestador

### 6. ConsultarNfsePorFaixa
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarNfseFaixaEnvio` com prestador e faixa de números de NFS-e

### 7. ConsultarNfseServicoPrestado
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarNfseServicoPrestadoEnvio` com prestador e filtros de consulta

### 8. ConsultarNfseServicoTomado
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarNfseServicoTomadoEnvio` com consulente e filtros de consulta

### 9. ConsultarUrlNfse
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `ConsultarUrlNfseEnvio` com prestador e opções de consulta (número, período de emissão ou competência)

### 10. GerarNfse
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `GerarNfseEnvio` com DPS completo (conforme schema TCDPS)

### 11. RecepcionarLoteDps
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `EnviarLoteDpsEnvio` com lote de DPSs

### 12. RecepcionarLoteDpsSincrono
- **nfseCabecMsg**: Cabeçalho padrão com versão
- **nfseDadosMsg**: `EnviarLoteDpsSincronoEnvio` com lote de DPSs (versão síncrona)

## Observações Importantes

1. **Cabeçalho (nfseCabecMsg)**: Todos os exemplos usam o mesmo cabeçalho padrão com versão 1.00
2. **Namespace**: Os elementos principais usam o namespace `http://www.sped.fazenda.gov.br/nfse` ou `http://www.abrasf.org.br/nfse.xsd` conforme o padrão
3. **Assinatura Digital**: Os arquivos que requerem assinatura digital incluem a estrutura básica do elemento `Signature`
4. **Valores Placeholder**: Os valores marcados com `?` devem ser substituídos pelos dados reais
5. **Schemas Complexos**: Para operações como `GerarNfse` e `RecepcionarLoteDps`, consulte o schema completo em `complexTypes.xsd` para a estrutura completa do DPS

## Uso no SoapUI

Para usar estes exemplos no SoapUI:

1. Abra o projeto `NfseNacional-soapui-project.xml`
2. Para cada operação, copie o conteúdo de `{Operacao}-nfseCabecMsg.xml` para o campo `nfseCabecMsg`
3. Copie o conteúdo de `{Operacao}-nfseDadosMsg.xml` para o campo `nfseDadosMsg`
4. Substitua os valores `?` pelos dados reais
5. Preencha a assinatura digital quando necessário

## Referências

- Padrão ABRASF NFS-e Nacional v1.01
- Schemas XSD disponíveis em `src/Abrasf.Web/Schemas/nacional/`

