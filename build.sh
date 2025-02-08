#!/usr/bin/env bash

set -eu
set -o pipefail

dotnet run --project ./build/build.fsproj "$@"