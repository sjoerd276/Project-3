fileIn1 = 'weerRo.csv'
fileOut1 = 'FixedThatForYou.csv'
column1 = 1
column2 = 0
KNMI = True
dateFix = False
dagJaar = 0
temperatuurGem = 0
hourCounter = 0
monthCounter = 1
fixTemp = 1
rows = []

import csv

stationDict = {}
typeDict = {}
weatherStations = 'Weerstations.csv'
columnTypes = 'Kolommen.csv'
with open(weatherStations) as csvweatherStations:
    with open(columnTypes) as csvcolumnTypes:
        weatherReader = csv.reader(csvweatherStations)
        typeReader = csv.reader(csvcolumnTypes)
        if KNMI:
            for row in weatherReader:
                stationDict[row[0]] = row[4]
            for row in typeReader:
                typeDict[row[0]] = row[1]

        with open(fileIn1) as csvfileIn1:

            csvfileIn1.seek(0)
            reader = csv.reader(csvfileIn1)

            for row in reader:
                if dateFix:
                    if row[column1][2] == "/" and len(row) > 1:
                        row[column1] = row[column1].replace("/", "")
                        date = [row[column1][:2], row[column1][2:4], row[column1][4:]]
                    elif row[column1][1] == "/" and len(row) > 0:
                        row[column1] = row[column1].replace("/", "")
                        date = [row[column1][:1], row[column1][1:3], row[column1][3:]]
                    else:
                        date = [row[column1][:4], row[column1][4:6], row[column1][6:]]
                    row = row[:column1] + date + row[(column1+1):]
                for i in range(len(row)):
                    row[i] = row[i].strip(" ")
                for i in range(len(row)):
                    if row[i] in typeDict:
                        row[i] = typeDict[row[i]]
                if row[0] in stationDict:
                    row[0] = stationDict[row[0]]

                if row[0] == "Jaar":
                    row.append("DagJaar")
                    row.append("TemperatuurGem")
                else:
                    if hourCounter == 0:
                        if not int(row[0]) == monthCounter:
                            dagJaar += int(row[2])
                            monthCounter = int(row[0])
                        else:
                            dagJaar += 1
                    row.append(str(dagJaar))
                    temperatuurGem += int(row[5])
                    hourCounter += 1
                    if hourCounter == 24:
                        temperatuurGem = round(temperatuurGem/24)
                        hourCounter = 0
                        row.append(str(temperatuurGem))
                        temperatuurGem = 0

                if row[0] == "ROTTERDAM" or row[0] == "Station" or not dateFix:


                    with open(fileOut1, 'a',  newline='') as csvfileOut1:
                        writer = csv.writer(csvfileOut1)
                        writer.writerow(row)