#!/usr/bin/env bash

main() {

  if test "$#" -eq 1; then
    echo "Hello, $*"
  else
    echo "Usage: error_handling.sh <person>" >&2
    exit 2
  fi
}

main "$@"
