   M S B A M L   `   `   `  ����   HuffmanEncodingDemo<    6Introduction2Algorithms.HuffmanEncodingDemo.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  HuffmanDemo��$	��480��$	��600��.���  � RowDefinitions �� $��* ��� $��40 �.+��  � ColumnDefinitions �� $��1* ��� $��1* ��� $��1* ��� $��1* �.+�� $��0��$��Stretch=�$��Stretch=� �� $��30 ��� $��* �.+��� Original text�� -    ��Name$ tb_ori��$��1�� �� TextWrapping$
 Wrap=�$��Stretch=�$��Stretch=�� $��1��$��Stretch=�$��Stretch=� �� $��30 ��� $��* �.+���  �� Orientation$ 
Horizontal=�.+��� 
ASCII Code�� $��10���� -    ��Name$ tb_bitnumber���� -   $ tb_assic��$��1��$
 Wrap=�$��Stretch=�$��Stretch=�� $��2��$��Stretch=�$��Stretch=� �� $��30 ��� $��* �.+��� $ 
Horizontal=�.+��� Huffman code�� $��10���� -   $ tb_hufbitnumber���� -   $ 	tb_encode��$��1��$
 Wrap=�$��Stretch=�$��Stretch=�� $��3��$��Stretch=�$��Stretch=� �� $��30 ��� $��* �.+��� Huffman decoded text�� -   $ 	tb_decode��$��1��$
 Wrap=�$��Stretch=�$��Stretch=��� $��1��$ 
Horizontal=�.+��� -    ��Name$ btn_load��$��	10,8,10,8q�.��Load english document�� -   $ 
btn_encode��$��	10,8,10,8q�.��Encode�� -	   $ 
btn_decode��$��	10,8,10,8q�.��Decode