   M S B A M L   `   `   `  ����   OutlineWPFDemo7    1Introduction2Algorithms.OutlineWPFDemo.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Outline Demo��$	��580��$	��680��.��� 
�������$��20q� � RowDefinitions �� $��* ��� $
��Auto �.+��� -   $��scrollViewer��$��0��$��Visible=�$��Visible=�.���� -    ��Name$ canvas��$��Visible=�$��Visible=�$
��Left=�
�������$	��600��$	��280��z�V� .~���  �� ScaleY$ -1Q�T�  T� Y ��  �� ElementName$ canvas�� �� Path$ ActualHeight���  �� Orientation$ Vertical=�$��1�� � 	Resources 	 �� 
TargetType
 �� Property �� Value��%-   '��       �� "	 ��.��� 
 � ��$ 10q�.+��� $ 
Horizontal=�$��45��.+��� -    ��Name$ btn_GRB��$��Generate Random Buildings��$��23��$
��Left=�$	��Top=�$	��172���� -   $ btn_CO��$��Calculated Outline��$��23��$
��Left=�$	��Top=�$	��115���� -   $ btn_HS��$��Hide/Show Outline��$��23��$
��Left=�$	��Top=�$	��116���� -   $ btn_clr��$��Clear Canvas��$��23��$
��Left=�$	��Top=�$	��109���� $ 
Horizontal=�$��45��.+��� -   $ btn_LoadBuildings��$!��Load Original Building Data���� -   $ btn_LoadOutLines��$"��Load Calculated Outline Data��