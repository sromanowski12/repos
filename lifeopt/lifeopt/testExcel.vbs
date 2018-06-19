Set objExcel = CreateObject("Excel.Application")
objExcel.Application.Run "'C:\Users\sroma\OneDrive\Education\Projects\Online Programming Resources2.xlsm'!test"
objExcel.DisplayAlerts = False
objExcel.Application.Quit
Set objExcel = Nothing