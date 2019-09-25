//Control Codes from KX-P1081 User Manual

//-----------------
//Single Byte Codes
const byte BS  	=	0x08;	//	Backspace        	-	Print data in buffer and backspace one space before printing next character
const byte CAN 	=	0x18;	//	Cancel           	-	Clear all data in recv buffer
const byte CR  	=	0x0D;	//	Carriage Return  	-	Print all data in the buffer
const byte DEL 	=	0x7F;	//  Delete           	-	Deletes the last character in the buffer
const byte DC1 	=	0x11;	//  Device Control 1 	-	Selects the printer remotely, enabling it to receive data (ON LINE)
const byte DC2 	=	0x12;	//  Device Control 2 	-	Releases compressed character mode set by SI
const byte DC3 	=	0x13;	//  Device Control 3 	-	Deselects the printer remotely, disabling it from receiving data
const byte DC4 	=	0x14;	//  Device Control 4 	-	Releases the double width (elongated) mode set by SO or ESC+SO
const byte ESC 	=	0x1B;	//  Escape           	-	First byte of each multi-byte printer control command
const byte FF  	=	0x0C;	//  Form Feed        	-	Feeds paper to next top of form position after first printing any data in the buffer
const byte HT  	=	0x09;	//  Horizontal Tab   	-	Execute the horizontal TAB as designated by ESC+D+n,+n2+ ... +nx+O or ESC+e+O+n
const byte LF  	=	0x0A;	//  Line Feed        	-	Causes data in buffer to be printed and then executes a single line feed
const byte NL  	=	0x00;	//  Null             	-	Last byte of certain multi-byte printer control codes
const byte SI  	=	0x0F;	//  Shift In         	-	Sets the compressed printing character mode
const byte SO  	=	0x0E;	//  Shift Out        	-	Sets one-line double width (elongated) printing character mode
const byte VT  	=	0x0B;	//  Vertical Tab     	-	Executes the vertical TAB as designated by ESC+B+n,+n2+ ... +nx+O or ESC+e+1+n

//-----------------------
//Character Mode Commands
const byte PICA[2] 		=	{ESC,0x50};					//  Pica Pitch                       		-	ESC+P  				-	Sets printing to 10 characters per inch (80 characters per line), and selects draft fonts
const byte ELITE[2]		=	{ESC,0x4D};					//  Elite Pitch                      		-	ESC+M  				-	Sets printing to 12 characters per inch (96 characters per line), and selects draft fonts
const byte ELITE_IBM[2]	=	{ESC,0x3A};					//  Elite Pitch IBM Mode             		-	ESC+:  				-	Sets printing to 12 characters per inch (96 characters per line)
const byte DWP_S[3]		=	{ESC,0x57,0x01};			//  Double Width Printing Set        		-	ESC+W+01			-	Sets the double width (elongated) printing character mode
const byte DWP_R[3]		=	{ESC,0x57,NL};				//  Double Width Printing Release    		-	ESC+W+00			-	Releases the double width (elongated) printing character mode
const byte DWP_O[2]		=	{ESC,SO};					//  Double Width Printing (One-Line) 		-	ESC+SO  			-	Sets the one-line double width (elongated) printing character mode, released by LF
const byte COMP[2] 		=	{ESC,SI};					//  Compressed Printing Mode                     					-	Sets the compressed printing character mode (Identical to just SI)
const byte SUP_S[3]		=	{ESC,0x53,NL};				//  Superscript Printing Set         		-	ESC+S+00			-	Sets superscript mode with characters printed on the top-half of line, characters are reduced to 1/2 of their original height
const byte SUB_S[3]		=	{ESC,0x53,0x01};			//  Subscript Printing Set           		-	ESC+S+01			-	Sets subscript mode with characters printed on the bottom half of line,characters are reduced to 1/2 of their original height
const byte SUBSUP_R[2]	=	{ESC,0x54};					//	Subscript/Superscript Release

//-------------------
//Character Set Codes
const byte ITAL_S[2] 		=	{ESC,0x34};				//  Italic Characters Set					-	ESC+4				-	Selects Italic character printing
const byte ITAL_R[2] 		=	{ESC,0x35};				//  Italic Characters Release              	-	ESC+5				-	Releases Italic character printing
const byte ITAL_INT_S[2]	=	{ESC,0x36};				//  Italic International Characters Set    	-	ESC+6				-	Allocates locations 0d128- 0d159 (0x80- 0x9F) and 0d255 (0xFF) to italic international characters (effective only in Standard Mode)
const byte ITAL_INT_R[2]	=	{ESC,0x37};				//  Italic International Characters Release	-	ESC+7				-	Releases Italic international characters
/*	International Charsets								//	Selects any one of 10 international character sets
 *  ESC+R+n
 *  0 	-	USA
 *  1 	-	France
 *  2 	-	N/A
 *  3 	-	England
 *  4 	-	Denmark I
 *  5 	-	Sweden
 *  6 	-	Italy
 *  7 	-	Spain
 *  8 	-	Japan
 *  9 	-	Norway
 *	10	-	Denmark II
 */
const byte USA_CHAR[3]		=	{ESC,0x52,NL};			//  Selects USA Charset
const byte FRA_CHAR[3]		=	{ESC,0x52,0x01};		//  Selects France Charset
const byte ENG_CHAR[3]		=	{ESC,0x52,0x03};		//  Selects England Charset
const byte DAN_CHAR[3]		=	{ESC,0x52,0x04};		//  Selects Denmark I Charset
const byte SWE_CHAR[3]		=	{ESC,0x52,0x05};		//  Selects Sweden Charset
const byte ITA_CHAR[3]		=	{ESC,0x52,0x06};		//  Selects Italy Charset
const byte ESP_CHAR[3]		=	{ESC,0x52,0x07};		//  Selects Spain Charset
const byte JAP_CHAR[3]		=	{ESC,0x52,0x08};		//  Selects Japan Charset
const byte NOR_CHAR[3]		=	{ESC,0x52,0x09};		//  Selects Norway Charset
const byte DAN2_CHAR[3]		=	{ESC,0x52,0x0A};		//  Selects Denmark II Charset

//-----------------------
//	Printer Mode Commands
const byte IBM_GRPH_I[2]		=	{ESC,0x37};			//	IBM Graphics Printer Mode I				-	ESC+7				-	Selects IBM Graphics printer Mode I
const byte IBM_GRPH_II[2]		=	{ESC,0x36]};		//	IBM Graphics Printer Mode II			-	ESC+6				-	Selects IBM Graphics Printer Mode II
/* 	Programmable Printer Mode							//	Sets printer mode to Standard, IBM Matrix, IBM Graphics I, or IBM Graphics II mode
 *	ESC+m+n
 *	0	-	Standard
 *	1	-	IBM Matrix
 *	2	-	IBM Graphics I
 *	3	-	IBM Graphics II 
 */
const byte PROG_STD[3]			=	{ESC,0x6D,NL};		//	Standard Printer Mode
const byte PROG_IBM_MAT[3]		=	{ESC,0x6D,01};		//	IBM Matrix Mode
const byte PROG_IBM_GRPHI[3]	=	{ESC,0x6D,02};		//	IBM Graphics I Mode
const byte PROG_IBM_GRPHII[3]	=	{ESC,0x6D,03};		//	IBM Graphics II Mode
const byte EMPH_S[2]			=	{ESC,0x45};			//	Emphasis Mode Set						-	ESC+E				-	Sets printing to twice the original horizontal dot density
const byte EPMH_R[2]			=	{ESC,0x46};			//	Emphasis Mode Release					-	ESC+F
const byte DOUB_PRN_S[2]		=	{ESC,0x47};			//	Double Printing Mode Set				-	ESC+G				-	Sets printing of each line of data with two passes of the print head, feeding the paper 1/216" between the first and second pass
const byte DOUB_PRN_R[2]		=	{ESC,0x48};			//	Double Printing Mode Release			-	ESC+H
const byte UND_S[3]				=	{ESC,0x2D,0x01};	//	Underlining Mode Set					-	ESC+-+01			-	Sets continuous underlining of characters
const byte UND_R[3]				=	{ESC,0x2D,NL};		//	Underlining Mode Release				-	ESC+-+00
/*	Print Mode Selection Omitted	*/
const byte NLQ_PICA[2]			=	{ESC,0x6E};			//	Near Letter Quality Pica Pitch Mode		-	ESC+n				-	Sets Pica Pitch printing of each line of data in NLQ font
const byte NLQ_ELITE[2]			=	{ESC,0x6F};			//	Near Letter Quality Elite Pitch Mode	-	ESC+o				-	Sets Elite Pitch printing of each line of data in NLQ font
const byte CPI_10[3]			=	{ESC,0x77,NL};		//	Character Pitch Selection				-	ESC+w+00			-	Selects 10 CPI pitch
const byte CPI_12[3]			=	{ESC,0x77,0x01};	//	Character Pitch Selection				-	ESC+w+01			-	Selects 12 CPI pitch
const byte CPI_15[3]			=	{ESC,0x77,0x02};	//	Character Pitch Selection				-	ESC+w+02			-	Selects 15 CPI pitch
const byte CPI_17[3]			=	{ESC,0x77,0x03};	//	Character Pitch Selection				-	ESC+w+03			-	Selects 17 CPI pitch
const byte NLQ_MODE[3]			=	{ESC,0x78,0x01};	//	Font Selection							-	ESC+x+01			-	Selects NLQ Font
const byte DFT_MODE[3]			=	{ESC,0x78,NL};		//	Font Selection							-	ESC+x+00			-	Selects Draft Font
const byte PROP_S[3]			=	{ESC,0x70,0x01};	//	Proportional Spacing Mode Set			-	ESC+p+01			-	Sets printing of each line of data using proportional spacing between characters
const byte PROP_R[3]			=	{ESC,0x70,NL};		//	Proportional Spacing Mode Release		-	ESC+p+00

//--------------------------
//	Word Processing Commands
const byte LEFT_ALGN[3]			=	{ESC,0x97,NL};		//	Left Alignment							-	ESC+a+00			-	Enables left alignment of a print line at left margin
const byte AUTO_CENT[3]			=	{ESC,0x97,0x01};	//	Auto Centering							-	ESC+a+01			-	Enables automatic centering of a print line between left and right margins
const byte RGHT_ALGN[3]			=	{ESC,0x97,0x02};	//	Right Alignment							-	ESC+a+02			-	Enables right alignment of a print line at right margin
const byte AUTO_JUST[3]			=	{ESC,0x97,0x03};	//	Auto Justification						-	ESC+a+03			-	Enable automatic justification of a print line between left and right margins

/*	Bit Image (Graphics) Mode Commands Omitted	*/

//-----------------------
//	Line Spacing Commands
const byte LS_1in8[2]			=	{ESC,0x30};			//	1/8in Line Spacing						-	ESC+0				-	Sets line spacing to 1/8in
const byte LS_7in72[2]			=	{ESC,0x31};			//	7/72in Line Spacing						-	ESC+1				-	Sets line spacing to 7/72in
const byte LS_1in6[2]			=	{ESC,0x32};			//	1/6in Line Spacing						-	ESC+2				-	Sets line spacing to 1/6in
//	FUNCTIONS
byte LS_nin72[3]			=	{ESC,0x41,0x01};		//	n/72 Inch Line Spacing					-	ESC+A+nn			-	Sets programmable line spacing to n/72 inch (0<=n<=85) Default 1/72
byte LS_nin216[3]			=	{ESC,0x33,0x01};		//	n/216 Inch Line Spacing					-	ESC+3+nn			-	Sets programmable line spacing to n/216 inch (0<=n<=255) Default 1/216
byte LS_nin216[3]			=	{ESC,0x33,0x01};		//	n/216 Inch Single Line Spacing			-	ESC+J+nn			-	Prints out the data in print buffer, and spaces n/216 inch (0<=n<=255) Default 1/216

//---------------------
//	Paper Feed Commands
//	FUNCTIONS
byte SKIP_PERF_S[3]		=	{ESC,0x4E,0x03};			//	Skip Perforation						-	ESC+N+nn			-	Sets skip-over perforation. nn specifies the number of lines (or n times the current line spacing amount) to be skipped at the bottom of the form

//----------------------
//	Page Format Commands
//	FUNCTIONS
byte HT_S[35]			=	{ESC,0x44,0x01,0x08,0x14,0x1E,0x2D,NL}	//	Horizontal Tab Set			-	ESC+D+n1...nx+00	-	Sets horizontal tabulation to specified values. Max of 32 tabs in a single line. HT single-byte command is called to execute tab designation
byte HT_R[3]			=	{ESC,0x44,NL};				//	Horizontal Tab Release					-	ESC+D+00
byte HTU[4]				=	{ESC,0x65,NL,0x08};			//	Horizontal Tab Unit						-	ESC+e+00+nn			-	Sets horizontal tabulation every n positions, beginning at the left margin, released when n = 0, default value 8
byte VT_S[19]			=	{ESC,0x42,0x03,0x07,NL}		//	Vertical Tab Set						-	ESC+B+n1...nx+00	-	Sets vertical tabulation to specified values. Max of 16 tabs in a single line. VT single-byte command is called to execute tab designation
byte VT_R[3]			=	{ESC,0x42,NL};				//	Vertical Tab Release					-	ESC+B+00
byte VTU[4]				=	{ESC,0x65,0x01,0x05};		//	Vertical Tab Unit						-	ESC+e+1+nn			-	Set vertical tabulation every n lines, beginning at top of form. Released by n = 1, or form length designation. Set default n = 5. If n = 0, data printed but paper not fed
byte FRM_LEN_IN[4]		=	{ESC,0x43,NL,0x0B};			//	Form Length (Inches)					-	ESC+C+00+nn			-	Sets page length in inches. Upon receipt, present line position becomes top of form. Set default 11in for A4/Letter
byte FRM_LEN_LN[3]		=	{ESC,0x43,NL};				//	Form Length (Lines)						-	ESC+C+nn			-	Sets page length in number of lines. 1<=nn<=127. If nn=00, page length reverts to inches
byte LFT_MAR[3]			=	{ESC,0x6C,0x03};			//	Left Margin								-	ESC+l+nn			-	Sets position of left margin in characters
byte RGT_MAR[3]			=	{ESC,0x51,0x50};			//	Right Margin							-	ESC+Q+nn			-	Sets position of right mmargin (effective only in Standard Mode)
byte HRZ_SPA[4]			=	{ESC,0x66,NL,0x01};			//	Horizontal Spacing						-	ESC+f+00+nn			-	Skips nn spaces between present and next character positions. 0<=nn<=127
byte VRT_SPA[4]			=	{ESC,0x66,0x01,0x01};		//	Vertical Spacing						-	ESC+f+01+nn			-	Advances paper nn lines after printer data in buffer. 0<=nn<=127

//-----------------------
//	Data Control Commands
const byte MSB_ON[2]			=	{ESC,0x3E};			//	MSB On									-	ESC+>				-	Sets the MSB to 1. Has no effect on bit image data. Released by ESC+#
const byte MSB_OFF[2]			=	{ESC,0x3D};			//	MSB Off									-	ESC+=				-	Sets the MSB to 0. Has no effect on bit image data. Released by ESC+#
const byte MSB_CAN[2]			=	{ESC,0x23};			//	MSB Cancel								-	ESC+#				-	Sets printer to receive 8th bit "as is". Has no effect on bit image data
const byte REM_DES_IBM[3]		=	{ESC,0x51,0x03};	//	Remote Deselect Printer (IBM Mode)		-	ESC+Q+03			-	Deselects the printer remotely, disabling it from receiving data. All data sent in deselect status become invalid. In order to return to select status, send DC1 code. Not operational in Standard Mode

/*	Dpwnloadable Character Commands Omitted	*/

//-----------------------
//	Miscellaneous Command
const byte HOME[2]				=	{ESC,0x3C};			//	Home Print Head							-	ESC+<				-	Causes the print head to return to its home position
const byte RESET[2]				=	{ESC,0x40};			//	Reset Printer							-	ESC+@				-	Initialises printer, causing data in the print buffer, but not in the receive buffer, to be cleared
const byte HALF_SPD_S[3]		=	{ESC,0x73,0x01};	//	Half Speed Printing	Set					-	ESC+s+01			-	Sets printing to half speed. Half speed printing can be set only in the pica, elite, standard density image, double speed double density image, and 576 dots/line image modes
const byte HALF_SPD_R[3]		=	{ESC,0x73,NL};		//	Half Speed Printing Release				-	ESC+s+00
const byte SNGL_DIR_S[3]		=	{ESC,0x55,0x01};	//	Single Direction Set					-	ESC+U+01			-	Sets single direction (left to right) printing mode
const byte SNGL_DIR_R[3]		=	{ESC,0x55,NL};		//	Single Direction Release				-	ESC+U+00