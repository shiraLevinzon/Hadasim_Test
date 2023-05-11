option = int(input("ENTER 1, 2 OR 3\n"))  # user choise input

while option != 3:  #
    hight = int(input("ENTER HIGHT"))
    width = int(input("ENTER WIDTH"))

    if option == 1:  # case rectangle
        if hight == width or abs(hight - width) > 5:  # case Square or The difference is greater than 5
            print(str(hight * width))  # print Area
        else:
            print(str(hight * 2 + width * 2))  # print scope

    elif option == 2:  # case triangle
        sq = ((width / 2) ** 2 + hight ** 2)  # Calculation of the sides of the calves using the Pythagorean theorem
        print((sq ** 0.5) * 2 + width)
        if width % 2 == 0 or width > hight * 2:  # In case the triangle cannot be printed according to the exercise
            # format
            print("The triangle cannot be printed.")
        else:
            for i in range(width // 2):  # print the top line
                print(' ', end='')
            print('*')
            if width == 3:  # A special case where the width of the triangle is equal to 3 - that is, the middle rows
                # must have an asterisk or 3 asterisks
                for i in range(hight - 2):
                    print(' * ')
            else:
                # hight/2- the number of lines to be printed except the first and last
                # (width-3)/2- the amount of numbers between 1 and width not including both
                # Dividing both of them will give us how many lines we need to print of each
                # type (based on the fact that each line with a different number of asterisks is defined as a type)
                whole = int((hight - 2) // ((width - 3) / 2))
                # What is not divisible - the number of lines with 3 stars that must be added above
                rest = (hight - 2) % ((width - 3) / 2)
                count = 3  # The number of asterisks
                for i in range((width - 3) // 2):  # The number of row types
                    numOfLines = whole + rest  # for the first iteration
                    rest = 0
                    for j in range(int(numOfLines)):  # The number of lines to print of this type
                        for k in range((width - count) // 2):  # Print the earnings
                            print(' ', end='')
                        for k in range(count):  # The printing of the stars
                            print('*', end='')
                        print()
                    count += 2

            for i in range(width):  # Prints the bottom line
                print('*', end='')
            print()
    else:
        print("your option isnt valid")

    option = int(input("ENTER 1, 2 OR 3\n"))

# if rest != 0:
#       numOfLines = shalem + 1
#        rest -= 1
#    else:
#        numOfLines = shalem
