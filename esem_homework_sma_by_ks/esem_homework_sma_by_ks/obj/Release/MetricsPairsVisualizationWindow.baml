   M S B A M L   `   `   `  ���� |  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting   esem_homework_sma_by_ks=   7esem_homework_sma_by_ks.MetricsPairsVisualizationWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     -     � Title$%  MetricsPairsVisualizationWindow��$��508.647��$��705.422��.��� .+�>   8System.Windows.Controls.DataVisualization.Charting.Chart  -   $��MetricPairChart��
 �� Top$ 80�� �� Left$ 10��$	��552��$	��250��
����İ�$
��Left=�$	��Top=�   Series F   @System.Windows.Controls.DataVisualization.Charting.ScatterSeries  ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Scatter��H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding ��  �� Path$	 Key�   DependentValueBinding �� $ Value�   DataPointStyle �� 	 �� 
TargetTypeI   CSystem.Windows.Controls.DataVisualization.Charting.ScatterDataPoint"	  .��� 
 �� Property
 � �� �� Value
 ����C   =System.Windows.Controls.DataVisualization.Charting.LineSeries  $ Linear�� �� $	 Key� �� $ Value� �� F   @System.Windows.Controls.DataVisualization.Charting.LineDataPoint"	  .��� 
 � ��
 �����  $ Logarithmic�� �� $	 Key� �� $ Value� �� "	  .��� 
 � ��
 �z���  $ 
Polynomial�� �� $	 Key� �� $ Value� �� "	  .��� 
 � ��
 �  ��   Axes C   =System.Windows.Controls.DataVisualization.Charting.LinearAxis  -     Name$ YLinearAxis��=	   7System.Windows.Controls.DataVisualization.Charting.Axis 	  Orientation$ Y=�D
   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis 
  Title$  ��
���   �
�������$��TimesNewRoman)�$��14(�$
��Bold"�  -   $ XLinearAxis��$ X=�$  ��
���   �
�������$��TimesNewRoman)�$��14(�$
��Bold"��� -    ��Name$ MetricsPairsListBox��$
��Left=�$	��250��$��	557,0,0,0q�$	��Top=�$	��130���� $��Correlation Coefficient:��$
��Left=�$��
10,255,0,0q�$	��Top=��� -    ��Name$! CorrelationCoefficientLabel��$�� ��$
��Left=�$��143,255,0,0q�$	��Top=��� $��Linear:��$
��Left=�$��
10,286,0,0q�$	��Top=�$��75���� $��Logarithmic:��$
��Left=�$��
10,317,0,0q�$	��Top=��� $��Polynomial:��$
��Left=�$��
10,348,0,0q�$	��Top=�$��75���� -    ��Name$# FirstLinearCoefficientTextBox��$
��Left=�$��23��$��
90,290,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� -   $( "FirstLogarithmicCoefficientTextBox��$
��Left=�$��23��$��
90,321,0,0q�$
 Wrap=�$	��Top=�$	��120���� -	   $' !FirstPolynomialCoefficientTextBox��$
��Left=�$��23��$��
90,352,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��x��$
��Left=�$��215,286,0,0q�$	��Top=�$��40���� -
   $$ SecondLinearCoefficientTextBox��$
��Left=�$��23��$��260,290,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��log(x)��$
��Left=�$��215,317,0,0q�$	��Top=��� -   $) #SecondLogarithmicCoefficientTextBox��$
��Left=�$��23��$��260,321,0,0q�$
 Wrap=�$	��Top=�$	��120���� $	��x^2��$
��Left=�$��215,348,0,0q�$	��Top=�$��40���� -   $( "SecondPolynomialCoefficientTextBox��$
��Left=�$��23��$��260,352,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��x��$
��Left=�$��385,348,0,0q�$	��Top=��� -   $' !ThirdPolynomialCoefficientTextBox��$
��Left=�$��23��$��406,352,0,0q�$
 Wrap=�$	��Top=�$	��120���� -    ��Name$ PolynomialPlottingButton��$
��Plot��$
��Left=�$��531,351,0,0q�$	��Top=�$��75���� -   $ LogarithmicPlottingButton��$
��Plot��$
��Left=�$��531,320,0,0q�$	��Top=�$��75���� -   $ LinearPlottingButton��$
��Plot��$
��Left=�$��531,289,0,0q�$	��Top=�$��75���� -   $ BestLineFitResultLabel��$�� ��$
��Left=�$��104,403,0,0q�$	��Top=��� -   $$ BestLineFitDeterminationButton��$��	Determine��$
��Left=�$��
10,406,0,0q�$	��Top=�$��75��