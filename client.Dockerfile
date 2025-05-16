# Etapa de build
FROM node:20 AS build
WORKDIR /app

# Copiar arquivo de configuração do npm e instalar dependências
COPY ./client/package*.json ./
RUN npm install

# Copiar código fonte e construir a aplicação
COPY ./client/ .
RUN npm run build -- --configuration production

# Etapa final com Nginx para servir a aplicação
FROM nginx:alpine
COPY --from=build /app/dist/titulo-devedor/browser /usr/share/nginx/html
COPY ./client/nginx.conf /etc/nginx/conf.d/default.conf

# Expor a porta usada pelo Nginx
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]