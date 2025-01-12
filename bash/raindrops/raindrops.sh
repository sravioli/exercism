#!/usr/bin/env bash

function main() {
  local result=""
  local is_divisible=false

  if (($1 % 3 == 0)); then
    result="${result}Pling"
    is_divisible=true
  fi

  if (($1 % 5 == 0)); then
    result="${result}Plang"
    is_divisible=true
  fi

  if (($1 % 7 == 0)); then
    result="${result}Plong"
    is_divisible=true
  fi

  if [[ "${is_divisible}" == false ]]; then
    echo "$1"
    return 0
  fi

  echo "${result}"
  return 0
}

main "$@"
