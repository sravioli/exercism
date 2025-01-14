#include "grains.h"

#define MAX_SQUARES 64

uint64_t square(uint8_t index) {
  if (index > MAX_SQUARES) {
    return 0;
  } else if (index <= 2) {
    return index;
  }

  uint64_t sq = 2;
  for (int i = 2; i < index; i++) {
    sq *= 2;
  }
  return sq;
}

uint64_t total(void) {
  uint64_t sq = 2;
  uint64_t sum = 3;  // 1st + 2nd
  for (int i = 1; i <= MAX_SQUARES; i++) {
    sq *= 2;
    sum += sq;
  }
  return sum;
}
