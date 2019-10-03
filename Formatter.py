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
    printerArray += wordArray

bold = False
underline = False
italics = False


n = 0
for j in printerArray:
    print("{}:".format(n), sep=":", end=" ")
    print(j)
    n += 1
