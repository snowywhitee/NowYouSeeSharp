   M S B A M L   `   `   `  ���� A  =Parser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ParserParser      Parser.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:Parser     $��15(�  � WindowStartupLocation$  CenterScreen=� � Title$ 
MainWindow��$	��610��$
��1100��.���  � ColumnDefinitions �� $��40 ��� $��* ��� $��15 ��� $��* ��� $��15 ��� $��* ��� $��15 ��� $��* ��� $��40 � � RowDefinitions �� $��40 ��� $��40 ��� $��15 ��� $��25 ��� $��15 ��� $��* ��� $��25 ��� $��50 ��� $��40 �.+��� -   $��prompt��$��1��$��5��$��7��$��Center=�$��30(� �� TextAlignment$ Center=�-+Пожалуйста, подскажите,�� 75куда сохранять нашу (Вашу) бд?�� $"..или где её искать?�� -   $��inputBox��$��2��$��5��$��4��   TextBoxStyle#��[   �� 
IsReadOnly$ False�� �� 
AcceptsTab$ False��$��50��$��Center=�$��Center=�.��C:/..�� -   $��submitButton��$��2��$��5��$��4��$��50��$	��200��$��Bottom=�$��Сабмит!��  ButtonStyle#��[ �� -   $��msgBox��$��1��$��1��$��7��$��15(�$��Приветики)))��$y�Hidden=�	� -   $��	ShortView��$��1��$��3��$��Сокращенно��  RadioButtonStyle#��[  d� 	IsChecked$
 TrueY�$y�Hidden=�$	��100��$
��Left=�	� -   $��FullView��$��1��$��3��$��Полностью��#��[ $
��Left=�$	��100��$��	110,0,0,0q�$y�Hidden=��� -   $��PageBack��$��7��$��3��$��35��$��25��$��<��$
��Left=�#��[ $y�Hidden=�$��Center=��� -   $��PaginationLabel��$��7��$��3��$��70��$��12(�$��Center=�$��45,0,0,0q�$��1 of 1��$
��Left=�$y�Hidden=��� -	   $��PageForward��$��7��$��3��#��[ $
��Left=�$��25��$��	100,0,0,0q�$��Center=�$��35��$��>��$y�Hidden=��� -
    ��Name$ NumberOfRecords��$��7��$��3��$��50��$
��Left=�$��	140,0,0,0q�$y�Hidden=�	 �� SelectedValue$	 20������ *pageRecords+&   System.Windows.Controls.DataGrid  -   $��dataGrid��$��1��$��7��$��5��
   AutoGenerateColumns$
 False��$y�Hidden=�   
IsReadOnly$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *IdStr+   HeaderStyle ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value �� .R��� $
��Wrap=�$-��'Идентификатор угрозы��   ElementStyle �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 2*  �� *Name+ �� "  .���  � �� �� .R��� $
��Wrap=�$+��%Наименование угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 3*  �� *Description+ �� "  .���  � �� �� .R��� $
��Wrap=�$#��Описание угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 2*  �� *Source+ �� "  .���  � �� �� .R��� $
��Wrap=�$#��Источник угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 2*  �� *Target+ �� "  .���  � �� �� .R��� $
��Wrap=�$6��0Объект воздействия угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ *  �� *ConfidentialityBreach+ �� "  .���  � �� �� .R��� $
��Wrap=�$=��7Нарушение конфиденциальности�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ *  �� *IntegrityViolation+ �� "  .���  � �� �� .R��� $
��Wrap=�$/��)Нарушение целостности�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�     Header$/ )Нарушение доступности��$ *  �� *AccessibilityViolation+ �� "  .���  � �� �� .R��� $
��Wrap=�$/��)Нарушение доступности�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  -   $��dataGridShort��$��1��$��7��$��5��$
 False��$y�Hidden=�$
 True������ *data+   $ *  �� *IdStr+ �� "  .���  � �� �� .R��� $
��Wrap=�$-��'Идентификатор угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 4*  �� *Name+ �� "  .���  � �� �� .R��� $
��Wrap=�$+��%Наименование угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  -   $��dataGridUpdated��$��1��$��7��$��5��$
 False��$y�Hidden=�$
 True��   $ *  �� *Id+ �� "  .���  � �� �� .R��� $
��Wrap=�$-��'Идентификатор угрозы�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ *  �� *	StatusStr+ �� "  .���  � �� �� .R��� $
��Wrap=�$��Статус�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 4*  �� *Before+ �� "  .���  � �� �� .R��� $
��Wrap=�$��Было�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $ 4*  �� *After+ �� "  .���  � �� �� .R��� $
��Wrap=�$��
Стало�� �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=��� -   $��Refresh��$��1��$��7��#��[ $��Обновить БД��$y�Hidden=��� -   $��BeforeAfter��$��3��$��7��#��[ $��Было/Стало��$y�Hidden=�${�False���� -   $��
SaveToFile��$��5��$��7��#��[ $$��Сохранить в файл��$y�Hidden=�$��1��$��1���� -   $
��Exit��$��7��$��7��#��[ $��
Выход��$y�Hidden=�