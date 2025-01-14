#include "resistor_color.h"

#include <stdlib.h>

int color_code(resistor_band_t resistor) { return (int)resistor; }

resistor_band_t *colors() {
  resistor_band_t *colors =
    (resistor_band_t *)malloc(sizeof(resistor_band_t) * ((int)WHITE + 1));
  for (resistor_band_t color = BLACK; color <= WHITE; color++) {
    colors[color] = color;
  }
  return colors;
}
