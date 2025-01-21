#include "queen_attack.h"

attack_status_t can_attack(position_t queen_1, position_t queen_2) {
  uint64_t x1 = queen_1.column, y1 = queen_1.row;
  uint64_t x2 = queen_2.column, y2 = queen_2.row;

  int is_col_equal = x1 == x2;
  int is_row_equal = y1 == y2;
  if (x1 > 7 || y1 > 7 || x2 > 7 || y2 > 7 || (is_col_equal && is_row_equal)) {
    return INVALID_POSITION;
  }

  int are_on_diagonal = (x1 - x2) == (y1 - y2) || (x1 + y1) == (x2 + y2);
  if (is_col_equal || is_row_equal || are_on_diagonal) {
    return CAN_ATTACK;
  }

  return CAN_NOT_ATTACK;
}
