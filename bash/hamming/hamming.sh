#!/usr/bin/env bash

# The following comments should help you get started:
# - Bash is flexible. You may use functions or write a "raw" script.
#
# - Complex code can be made easier to read by breaking it up
#   into functions, however this is sometimes overkill in bash.
#
# - You can find links about good style and other resources
#   for Bash in './README.md'. It came with this exercise.
#
#   Example:
#   # other functions here
#   # ...
#   # ...
#
#   main () {
#     # your main function code here
#   }
#
#   # call main with all of the positional arguments
#   main "$@"
#
# *** PLEASE REMOVE THESE COMMENTS BEFORE SUBMITTING YOUR SOLUTION ***

declare -gA NUCLEOTIDES=(
  ["C"]=true
  ["A"]=true
  ["G"]=true
  ["T"]=true
)

function is_nucleotide() {
  [[ "$1" == "C" ]] || [[ "$1" == "A" ]] || [[ "$1" == "G" ]] || [[ "$1" == "T" ]]
}

function main() {
  if [[ "$#" -lt 2 ]]; then
    echo "Usage: hamming.sh <string1> <string2>"
    exit 1
  fi

  local first second
  first="$1"
  second="$2"

  if [[ "${#first}" != "${#second}" ]]; then
    echo "strands must be of equal length"
    return 1
  fi

  declare -i count=0
  for ((i = 0; i < ${#first}; i++)); do
    ch1="${first:$i:1}"
    ch2="${second:$i:1}"

    if [[ "${ch1}" != "${ch2}" ]]; then
      count+=1
    fi
  done

  echo "${count}"
}

main "$@"
