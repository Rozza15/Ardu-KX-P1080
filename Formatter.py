import textwrap
import re

boldString = ""
italicString = ""
underlineString = ""

with open("testparagraph.txt","r") as payload:
    plainText = payload.read()
    payload.close()

printerArray = []
plainArray = textwrap.wrap(plainText)

for i in plainArray:
    wordArray = re.split(r'({b}|{i}|{u}|\s+)', i)
    printerArray += [wordArray]

bold = False
underline = False
italics = False


n = 0
for j in printerArray:
    for k in j:
        if k == "{b}":
            if bold:
                bold = False
            else:
                bold = True
        elif k == "{u}":
            if underline:
                underline = False
            else:
                underline = False
        elif k == "{i}":
            if italics:
                italics = False
            else:
                italics = True
        print("{}:".format(n), sep=":", end=" ")
        print("b: {}, u: {}, i: {}".format(bold, underline, italics))
        print(k)
        n += 1
