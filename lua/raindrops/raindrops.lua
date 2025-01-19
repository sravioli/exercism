return function(n)
  local drop = ""

  if n % 3 == 0 then
    drop = drop .. "Pling"
  end

  if n % 5 == 0 then
    drop = drop .. "Plang"
  end

  if n % 7 == 0 then
    drop = drop .. "Plong"
  end

  return #drop == 0 and tostring(n) or drop
end
