#!/usr/bin/env bash

function main() {
  local acronym
  local words

  words="$(echo "${1^^}" | sed -e's/-/ /g' | tr -d '[:punct:]')"
  for word in ${words}; do
    acronym+="${word:0:1}"
  done
  echo "${acronym}"
}

main "$@"
