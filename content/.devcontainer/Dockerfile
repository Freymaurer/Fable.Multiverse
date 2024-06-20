FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base


ENV \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    DOTNET_ROOT=/usr/share/dotnet/ \
    NODE_VERSION=20.10.0 \
    PYTHON_VERSION=3.11

# Install node
RUN apt-get update -y && apt install -y curl
RUN curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.0/install.sh | bash
ENV NVM_DIR=/root/.nvm
RUN . "$NVM_DIR/nvm.sh" && nvm install ${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm use v${NODE_VERSION}
RUN . "$NVM_DIR/nvm.sh" && nvm alias default v${NODE_VERSION}
ENV PATH="/root/.nvm/versions/node/v${NODE_VERSION}/bin/:${PATH}"
RUN node --version
RUN npm --version

# Install Python
RUN apt-get update -y && apt-get install python3 -y
RUN apt install python3.11-venv -y

# Verify installations
RUN dotnet --version \
    && node --version \
    && npm --version \
    && python3 --version

# Set the container's default command (optional)
CMD [ "bash" ]
