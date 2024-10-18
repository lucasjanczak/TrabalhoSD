#!/bin/bash
set -e

# Aplicar migrations
dotnet ef database update

# Iniciar a aplicação
exec dotnet Web.dll
