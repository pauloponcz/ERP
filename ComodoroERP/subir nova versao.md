1. Alterar o código
2. Alterar a versão no .csproj
3. Fazer commit/push do código para o GitHub
4. Rodar dotnet publish
5. Compactar a pasta publish em .zip
6. Criar uma nova Release no GitHub
7. Anexar o novo .zip na Release

## Exemplo prático

<Version>1.0.2</Version>
<AssemblyVersion>1.0.2.0</AssemblyVersion>
<FileVersion>1.0.2.0</FileVersion>

Depois sobe o código normalmente:

```powershell
git add .
git commit -m "feat: adiciona nova melhoria"
git pull --rebase origin main
git push
```

Depois gera a aplicação publicada:

```powershell
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true
```

Aí vai na pasta:

```text
ComodoroERP\bin\Release\net9.0-windows\win-x64\publish
```

Compacta os arquivos dessa pasta e renomeia para:

```text
ComodoroERP-v1.0.2.zip
```

Depois no GitHub você cria uma nova Release:

```text
Tag: v1.0.2
Título: Versão 1.0.2
Arquivo: ComodoroERP-v1.0.2.zip
```

## O `.zip` entra no Git normal?

Não. O `.zip` da aplicação publicada **não precisa ir no commit do código**.

Ele vai em:

```text
GitHub > Releases > Attach binaries
```

Ou seja:

```text
Código-fonte → git add / commit / push
Aplicação pronta para usuário → GitHub Release
```

## Diferença importante

O `git push` sobe o **código**:

```text
.cs
.csproj
.resx
Designer.cs
```

A Release sobe o **programa pronto**:

```text
ComodoroERP-v1.0.2.zip
```

## Regra simples de versionamento

Pode seguir assim:

```text
1.0.1 → primeira versão publicada
1.0.2 → correção pequena
1.0.3 → outra correção pequena
1.1.0 → melhoria maior
2.0.0 → mudança grande no sistema
```

Para o seu caso agora, usa simples:

```text
v1.0.1
v1.0.2
v1.0.3
v1.0.4
```
