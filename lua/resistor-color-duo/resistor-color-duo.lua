local resistor_colors = {
  ["black"] = 0,
  ["brown"] = 1,
  ["red"] = 2,
  ["orange"] = 3,
  ["yellow"] = 4,
  ["green"] = 5,
  ["blue"] = 6,
  ["violet"] = 7,
  ["grey"] = 8,
  ["white"] = 9,
}

return {
  value = function(colors)
    local num = ""

    for i = 1, 2 do -- max two items
      num = num .. resistor_colors[colors[i]]
    end

    return tonumber(num)
  end,
}
