# Retrieve official public Docker image of Node version 6.*
FROM node:6
# Expose the 'source' of the package, in order to allow overriding in Dev environment from docker-compose
ARG source
# Set the current directory to the /app directory
WORKDIR /app
# Expose the 4200 port (default Angular port)
EXPOSE 4200

# Copy all the content from the folder defined in the 'source' argument or from the current folder into the app directory of the container
COPY ${source:-.} .
# Restore npm packages
RUN npm install

# Specify process to be executed when starting the container
ENTRYPOINT ["npm", "start"]
