   M S B A M L   `   `   `  ���� 	  Music    Music.View.EditPageTrack   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       N� Title$  EditPageTrack��.���  � RowDefinitions �� $��* ��� $��4* ��� $��* �.+��� $��
Edit Track��$��0��$��30(�$
��Bold"�
�������$��0 20 0 0q�$��Center=�$��Center=��� $��2��$��Center=� �� Orientation$ 
Horizontal=�.+��� $	��200��$��35��$��20q�$
��Save�� � Cursor$
 Hand������ *UpdateCommand+����  �� 
TargetType" ��.���  �� Property � �� �� Value
 � � ���  � ��
 �������  � ��$ 0q���  � �� ��  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 20��._��� $��Center=�$��Center=��� $	��200��$��35��$��20q�$��Delete��$
 Hand������ *Deletecommand+���� " ��.���  � ��
 �  ����  � ��
 �������  � ��$ 0q���  � �� �� " ��.R��� #��z��#��z��#��z��$ 20��._��� $��Center=�$��Center=�� $��1��	 � ColumnDefinitions	 �� $��* ��� $��* �.+��� $��0��$��20q�.+��� $��Center=�$��16(�$
��Bold"�
�������$��
Name track���� -   
 ��Name$
 artistNameTextBox��$	��200��$��30��$
��0,10q�$��5q�$��Center=����� *Title+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��	0,20,0,10q�$��Center=�$��16(�$
��Bold"�
�������$��Genre���� -    ��Name$ genreComboBox��$	��200��$��30��$
��0,10q�$��5q�$��Center=� �� DisplayMemberPath$
 Name�� �� SelectedValuePath$ Id������ *Genres+ �� SelectedValue �� *	GenreId+$ TwoWay=��� $��1��$��
20,0,20,20q�.+��� $��0,10,0,0q�$��Center=�$��16(�$
��Bold"�
�������$��Choose Image���� -    ��Name$ selectImageButton��$	��198��$��30��$
��0,10q�$��Select Image���� -    ��Name$ selectedImage��$	��100��$	��100��$
��0,20q����� *Image+$ TwoWay=�$ PropertyChanged=�