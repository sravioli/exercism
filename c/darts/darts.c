#include "darts.h"

#include <math.h>

uint8_t score(coordinate_t coord) {
  float distance = sqrt(coord.x * coord.x + coord.y * coord.y);

  if (distance >= 0 && distance <= 1) {
    return 10;
  } else if (distance > 1 && distance <= 5) {
    return 5;
  } else if (distance > 5 && distance <= 10) {
    return 1;
  } else {
    return 0;
  }
}
