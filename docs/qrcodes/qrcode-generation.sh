#!/bin/bash

export EVENT='giocourbino'

mkdir $EVENT

# A

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-a1"
convert -density 900 template/pdf/a1.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	template/pdf/stars.pdf -geometry 1500x1500 -composite \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/a1.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-a2"
convert -density 900 template/pdf/a2.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/a2.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-a3"
convert -density 900 template/pdf/a3.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/a3.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-a4"
convert -density 900 template/pdf/a4.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	template/pdf/stars.pdf -geometry 1500x1500 -composite \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/a4.png
	
qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-a5"
convert -density 900 template/pdf/a5.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/a5.png

# B

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-b1"
convert -density 900 template/pdf/b1.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	template/pdf/stars.pdf -geometry 1500x1500 -composite \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/b1.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-b2"
convert -density 900 template/pdf/b2.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/b2.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-b3"
convert -density 900 template/pdf/b3.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/b3.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-b4"
convert -density 900 template/pdf/b4.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/b4.png
	
qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-b5"
convert -density 900 template/pdf/b5.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/b5.png

# C

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-c1"
convert -density 900 template/pdf/c1.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/c1.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-c2"
convert -density 900 template/pdf/c2.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/c2.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-c3"
convert -density 900 template/pdf/c3.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/c3.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-c4"
convert -density 900 template/pdf/c4.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/c4.png
	
qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-c5"
convert -density 900 template/pdf/c5.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	template/pdf/stars.pdf -geometry 1500x1500 -composite \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/c5.png

# D

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-d1"
convert -density 900 template/pdf/d1.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/d1.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-d2"
convert -density 900 template/pdf/d2.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/d2.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-d3"
convert -density 900 template/pdf/d3.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/d3.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-d4"
convert -density 900 template/pdf/d4.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/d4.png
	
qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-d5"
convert -density 900 template/pdf/d5.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/d5.png

# E

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-e1"
convert -density 900 template/pdf/e1.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/e1.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-e2"
convert -density 900 template/pdf/e2.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	template/pdf/stars.pdf -geometry 1500x1500 -composite \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/e2.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-e3"
convert -density 900 template/pdf/e3.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/e3.png

qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-e4"
convert -density 900 template/pdf/e4.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/e4.png
	
qrencode -o qrcode.png -s 30 -l M -m 0 "http://t.me/codymazebot?start=$EVENT-e5"
convert -density 900 template/pdf/e5.pdf -background "#FFFFFFFF" -resize 1500x1500 \
	qrcode.png -geometry 800x800+350+350 -composite \
	-flatten $EVENT/e5.png

# Cleanup

rm qrcode.png
