f = open("./input")
commands = f.readlines()

for i in range(len(commands)): 
    commands[i] = commands[i][:-1].split(' ') # remove \n and split them 

#1st part
horizontal = 0
depth = 0

for command in commands:
    if(command[0] == "forward"):
        horizontal += int(command[1])
    elif(command[0] == "up"):
        depth -= int(command[1])
    elif(command[0] == "down"):
        depth += int(command[1])

print(horizontal*depth)

#2nd pard
horizontal = 0
depth = 0
aim = 0

for command in commands:
    if(command[0] == "forward"):
        horizontal += int(command[1])
        depth += aim*int(command[1])
    elif(command[0] == "up"):
        aim -= int(command[1])
    elif(command[0] == "down"):
        aim += int(command[1])
        
print(horizontal*depth)