
# Etapa de build
FROM node:20 AS build
WORKDIR /app

# Copiar arquivo de configuração do npm e instalar dependências
COPY desafio/client/package*.json ./
RUN npm install

# Copiar código fonte e construir a aplicação
COPY desafio/client/ .
RUN npm run build -- --configuration production

# Etapa final com Nginx para servir a aplicação
FROM nginx:alpine
COPY --from=build /app/dist/client /usr/share/nginx/html
COPY desafio/client/nginx.conf /etc/nginx/conf.d/default.conf

# Expor a porta usada pelo Nginx
EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]