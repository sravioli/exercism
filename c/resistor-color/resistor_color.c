#include "resistor_color.h"

#include <stdlib.h>

int color_code(resistor_band_t resistor) { return resistor; }

resistor_band_t *colors() {
  static resistor_band_t colors[WHITE + 1];
  for (resistor_band_t color = BLACK; color <= WHITE; color++) {
    colors[color] = color;
  }
  return colors;
}
