#include "queen_attack.h"

#include <stdlib.h>

#define MAX_COLS 8
#define MAX_ROWS 8

inline static int on_board(position_t queen) {
  return queen.column < MAX_COLS && queen.row < MAX_ROWS;
}

attack_status_t can_attack(position_t queen_1, position_t queen_2) {
  int x1 = queen_1.column, y1 = queen_1.row;
  int x2 = queen_2.column, y2 = queen_2.row;

  int dx = abs(x1 - x2), dy = abs(y1 - y2);
  if (!on_board(queen_1) || !on_board(queen_2) || dx + dy == 0) {
    return INVALID_POSITION;
  }

  if (dx * dy == 0 || dx == dy) {
    return CAN_ATTACK;
  }

  return CAN_NOT_ATTACK;
}
