#!/usr/bin/env bash

function main() {
  local acronym
  local words

  words="$(sed --expression='s/-/ /g' <(echo "$1") | tr --delete '[:punct:]' | tr '[:lower:]' '[:upper:]')"
  for word in ${words}; do
    acronym="${acronym}${word:0:1}"
  done
  echo "${acronym}"
}

main "$@"
