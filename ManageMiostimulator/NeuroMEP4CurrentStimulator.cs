using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Resources;
using System.ComponentModel;
using System.Collections;
using System.Threading;
using System.Windows;
using System.Globalization;

namespace MiostimulatorClient
{
    public class NeuroMEP4CurrentStimulator
    {
        #region Константы

        //Коэффициент пересчета амплитуды в Амперах в разряды для задания в стимулятор
        public const float CurrentToCode = 41402.214022f;

        /// <summary>
        /// Частота квантования токового стимулятора
        /// = 40000
        /// </summary>
        public const int MaxFrecKvantCurrentStimulator = 40000;

        /// <summary>
        /// Максимальное количество точек в огибающей стимула для токового стимулятора
        /// = 2048
        /// </summary>
        public const int MaxCurrentStimulPoints = 2048;

        #endregion

        #region Поля

        private int checkError;

        private int handle = 1;

        /// <summary>
        /// Индикатор открытости устройства
        /// </summary>
        bool isOpen;

        /// <summary>
        /// Уровень стимуляции
        /// </summary>
        private int levelStimulation = 0;

        /// <summary>
        /// Полярность
        /// </summary>
        private int polarity;

        /// <summary>
        /// Форма стимула
        /// </summary>
        private StimulationFormType stimulationForm;

        /// <summary>
        /// Период стимуляции
        /// </summary>
        private double periodStimulation;

        /// <summary>
        /// Продолжительность стимуляции
        /// </summary>
        private float durationStimulation;

        /// <summary>
        /// Максимальная продолжительность стимуляции
        /// по требованиям безопасности один импульс не может превышать по длительности 5 мс - это искусственное ограничение
        /// </summary>
        private float maxDurationStimulation = 0.005f;

        /// <summary>
        /// Количество стимуляций
        /// </summary>
        private ushort countStimulations;

        /// <summary>
        /// Шаг изменения амплитуды
        /// </summary>
        private float amplitudeStep;

        /// <summary>
        /// Амплитуда стимуляции, А
        /// </summary>
        private float amplitudeStimulation;

        /// <summary>
        /// Максимальная амплитуда, A (искусственное ограничение)
        /// </summary>
        [DefaultValue(0.1f)]
        private float maximumAmplitude = 0.1f;

        private UInt16 frame = 0xffff;

        /// <summary>
        /// Коэффициент уменьшения частоты квантования стимулятора
        /// при значении коэффициента = 1 частота квантования 40000Гц
        /// при значении коэффициента = 4 частота квантования 10000Гц - нужно для увеличения продолжительности стимула до 200 мс для имитации лазерной стимуляции
        /// Необходимо учитывать, что при изменении частоты квантования пропорционально изменяются длительности стимулов, период стимуляции и задержка стимула - их необходимо корректировать
        /// </summary>
        [DefaultValue(1)]
        private double timeCoefficient = 1;

        /// <summary>
        /// Массив описывающий форму стимула
        /// </summary>
        private short[] stimulFormArray;

        /// <summary>
        /// Объект для организации критических секций при обращении к аппаратуре
        /// </summary>
        private object lockObject = new object();

        #endregion

        #region Свойства

        /// <summary>
        /// Количество стимулов
        /// </summary>
        public ushort CountStimulations
        {
            set
            {
                countStimulations = value;
            }
            get
            {
                return countStimulations;
            }
        }

        /// <summary>
        /// Период стимуляции
        /// </summary>
        public double PeriodStimulation
        {
            set
            {
                periodStimulation = value;
            }
            get
            {
                return periodStimulation;
            }
        }

        /// <summary>
        /// Шаг изменения амплитуды
        /// </summary>
        public float AmplitudeStep
        {
            set
            {
                amplitudeStep = value;
            }
            get
            {
                return amplitudeStep;
            }
        }

        /// <summary>
        /// Амплитуда стимуляции
        /// </summary>
        public float AmplitudeStimulation
        {
            set
            {
                if (value > maximumAmplitude)
                {
                    amplitudeStimulation = maximumAmplitude;
                }
                else
                {
                    amplitudeStimulation = value;
                }
            }        
            get
            {
                return amplitudeStimulation;
            }
        }

        /// <summary>
        /// Длительность стимуляции
        /// </summary>
        public float DurationStimulation
        {
            set
            {
                if (value > maxDurationStimulation)
                {
                    durationStimulation = maxDurationStimulation;
                }
                else
                {
                    durationStimulation = value;
                }
            }
            get
            {
                return durationStimulation;
            }
        }

        /// <summary>
        /// Полярность
        /// </summary>
        public int Polarity
        {
            set
            {
                if (value > 0)
                    polarity = 1;
                else
                    polarity = -1;
            }
            get
            {
                return polarity;
            }
        }

        /// <summary>
        /// Форма стимула
        /// </summary>
        public StimulationFormType StimulationForm
        {
            set
            {
                stimulationForm = value;
            }
            get
            {
                return stimulationForm;
            }
        }

        /// <summary>
        /// Уровень стимуляции
        /// Он увеличивается если с коррелятора приходит команда "3"
        /// и уменьшается если приходят команды "1" или "2".
        /// Значение уровеня стимуляции не может быть меньше 0.
        /// </summary>
        private int LevelStimulation
        {
            set
            {
                if (value < 0)
                {
                    levelStimulation = 0;
                }
            }
            get
            {
                return levelStimulation;
            }
        }

        #region Настройки прямоугольника

        /// <summary>
        /// Продолжительность, с
        /// </summary>
        float RectangleDuration
        {
            set { }
            get
            {
                return DurationStimulation;
            }
        }

        #endregion

        #region Настройки трапеции

        /// <summary>
        /// Длительность переднего фронта трапеции, с
        /// </summary>
        float T1
        {
            set { }
            get
            {
                return DurationStimulation / 3;
            }
        }

        /// <summary>
        /// Длительность средней части, с
        /// </summary>
        float T2
        {
            set { }
            get
            {
                return DurationStimulation / 3;
            }
        }

        /// <summary>
        /// Длительность заднего фронта трапеции, с
        /// </summary>
        float T3
        {
            set { }
            get
            {
                return DurationStimulation / 3;
            }
        }

        #endregion

        #region Настройки однополярного меандра 

        /// <summary>
        /// Частота (Гц)
        /// </summary>
        uint UnipolarMeandrFrequency
        {
            set { }
            get
            {
                return (uint)(1/periodStimulation);
            }
        }

        /// <summary>
        /// Продолжительность, c
        /// </summary>
        float UnipolarMeandrDuration
        {
            set { }
            get
            {
                return DurationStimulation;
            }
        }

        /// <summary>
        /// Скважность
        /// </summary>
        uint UnipolarMeandrSkvagnost
        {
            set { }
            get
            {
                return (uint)(periodStimulation/DurationStimulation);
            }
        }

        #endregion

        #region Настройки двухполярного меандра

        /// <summary>
        /// Частота (Гц)
        /// </summary>
        uint BipolarMeandrFrequency
        {
            set { }
            get
            {
                return (uint)(1 / periodStimulation);
            }
        }

        /// <summary>
        /// Продолжительность, с
        /// </summary>
        float BipolarMeandrDuration
        {
            set { }
            get
            {
                return DurationStimulation;
            }
        }

        #endregion

        #region Настройки синусоиды

        /// <summary>
        /// Частота (Гц)
        /// </summary>
        uint SinusoidFrequency
        {
            set { }
            get
            {
                return (uint)(1 / periodStimulation);
            }
        }

        /// <summary>
        /// Продолжительность, с
        /// </summary>
        float SinusoidDuration
        {
            set { }
            get
            {
                return DurationStimulation;
            }
        }

        #endregion

        #region Настройки модулированной синусоиды

        /// <summary>
        /// Частота (Гц)
        /// </summary>
        uint ModularSinusoidFrequency
        {
            set { }
            get
            {
                return (uint)(1 / periodStimulation);
            }
        }

        /// <summary>
        /// Продолжительность, с
        /// </summary>
        float ModularSinusoidDuration
        {
            set { }
            get
            {
                return DurationStimulation;
            }
        }

        #endregion        

        #endregion

        #region enum

        public enum StimulationFormType
        {
            rectangle,
            trapezium,
            bipolarMeandr,
            unipolarMeandr,
            sinusoid,
            modularSinusoid
        }

        #endregion

        #region Конструкторы

        public NeuroMEP4CurrentStimulator()
        {
            PeriodStimulation = 1;
            CountStimulations = 5;
            AmplitudeStimulation = 0.020f;
            DurationStimulation = 0.0005f;
            StimulationForm = StimulationFormType.rectangle;
            Polarity = 1;
            AmplitudeStep = 0.005f;
            isOpen = false;
            checkError = 0;
        }

        public NeuroMEP4CurrentStimulator(double periodStimulation, ushort countStimulations, float amplitudeStimulation, float durationStimulation, StimulationFormType stimulationForm, int polarity)
        {
            PeriodStimulation = periodStimulation;
            CountStimulations = countStimulations;
            AmplitudeStimulation = amplitudeStimulation;
            DurationStimulation = durationStimulation;
            StimulationForm = stimulationForm;
            Polarity = polarity;
            AmplitudeStep = 0.005f;
            isOpen = false;
            checkError = 0;
        }

        #endregion

        #region Функции из NsEzUSB.dll

        /*
        /// <summary>
        /// Запускает поток сообщений от прибора в интеррапт режиме
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="reciveMessage"></param>
        /// <param name="messageSize"></param>
        /// <returns></returns>
        [DllImport("NsEzUSB.dll")]
        public static extern uint StartMessageTrans(int hDevice, ReceiveInterruptMessageDelegate reciveMessage, UInt16 messageSize);

        /// <summary>
        /// Останавливает поток сообщений от interrupt канала
        /// </summary>
        /// <param name="idThread"></param>
        /// <returns></returns>
        [DllImport("NsEzUSB.dll")]
        public static extern bool StopMessageTrans(uint idThread);
        */

        /// <summary>
        /// Открытие устройства, работающего через драйвер Никонорова
        /// </summary>
        /// <param name="PID"></param>
        /// <param name="Number"></param>
        /// <returns></returns>
        [DllImport("NsEzUSB.dll")]
        public static extern int OpenNSoftDevNikDrv(ushort PID, byte Number);

        /// <summary>
        /// Возвращает количество приборов с данным PID на шине USB
        /// </summary>
        /// <param name="PID">PID прибора</param>
        /// <param name="SerNums">Серийные номера найденных придоров</param>
        /// <returns></returns>
        [DllImport("NsEzUSB.dll")]
        public static extern int EnumNSoftDev(uint PID, IntPtr SerNums);

        /// <summary>
        /// Закрывает прибор по Handle
        /// </summary>
        /// <param name="hDevice">Handle прибора</param>
        /// <returns></returns>
        [DllImport("NsEzUSB.dll")]
        public static extern bool CloseDev(int hDevice);

        #endregion

        # region Функции из ELECTROSTIM.dll

        /// <summary>
        /// Включение стимулятора
        /// </summary>
        /// <param name="hDevice"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroPowerOn(int hDevice);

        /// <summary>
        /// Выключение стимулятора
        /// </summary>
        /// <param name="hDevice"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroPowerOff(int hDevice);

        /// <summary>
        /// Загружает число, отображаемое на индикаторе стимулятора
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroLoadDigit(int hDevice, int value);

        /// <summary>
        /// Загружает число, отображаемое на индикаторе стимулятора (со знаком)
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="value"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroLoadDigitEx(int hDevice, int value, bool sign);

        /// <summary>
        /// Устанавливает количество стимулов
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="stimuls"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroNumberOfStim(int hDevice, UInt16 stimuls);

        /// <summary>
        /// Немедленное прекражение токовой стимуляции
        /// </summary>
        /// <param name="hDevice"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroStop(int hDevice);

        /// <summary>
        /// Устанавливает смену знака после каждого стимула
        /// </summary>
        /// <param name="nDevice"></param>
        /// <param name="changeSign"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetChangeSign(int nDevice, bool changeSign);

        /// <summary>
        /// Устанавливает форму стимула
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="stimul">указатель на массив, содержащий форму стимула, частота 40кГц</param>
        /// <param name="length">длина массива (не более 2048)</param>
        /// Цена деления - 0.0241532976827(0944741532976827) ма/дискр
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetStimul(int hDevice, IntPtr stimul, UInt16 length);

        /// <summary>
        /// Устанавливает период стимуляции (0.01 - 167.77215 с)
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="period">период стимуляциии в сек.</param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetPeriod(int hDevice, double period);

        /// <summary>
        /// Устанавливает с какого фрейма начинается стимуляция
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="frame">номер фрейма, если фрейм > 0xfff, то старт происходит немедленно</param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetStart(int hDevice, UInt16 frame);

        /// <summary>
        /// Устанавливает с какого фрейма начинается стимуляция с задержкой
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="frame">номер фрейма, если фрейм > 0xfff, то старт происходит немедленно</param>
        /// <param name="delay">задержка начала стимуляции, c</param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetStartEX(int hDevice, UInt16 frame, double delay);

        /// <summary>
        /// Устанавливает яркость свечения индикатора
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="bright">bright - яркость от 4 до 40</param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetBright(int hDevice, byte bright);

        /// <summary>
        /// Запрос номера версии прибора
        /// 0 - в случае неудачи или старого стимулятора
        /// </summary>
        /// <param name="hDevice"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern float ElectroGetVerNo(int hDevice);

        /// <summary>
        /// Функция задания новой частоты квантования
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="Correction"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetSamplingPeriodCorrection(int hDevice, double Correction);

        /// <summary>
        /// Устанавливает активный канал коммутатора токового стимулятора
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="chanel"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetCommutatorChannel(int hDevice, uint chanel);

        /// <summary>
        /// Устанавливает очередность каналов коммутатора токового стимулятора
        /// (для эмуляции многоканального стимулятора)
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="chanel"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetCommutatorChannels(int hDevice, uint[] chanel);

        /// <summary>
        /// Устанавливает активный канал коммутатора токового стимулятора
        /// HANDLE hDevice - HANDLE устройства;
        /// unsigned int chanel	-	 массив номеров номер канала. 	
        /// WORD* stimul - указатель на массив, содержащий форму стимула, частота 40 кГц;(см. прим. про корректирующий коэффициент)
        /// WORD length - длина массива, не более 127.
        /// 
        /// 	Цена деления - 0.0244140625 //0.0241532976827(0944741532976827) мА/дискр.
        /// Возвращает ненулевое значение в случае успеха
        /// </summary>
        /// <param name="hDevice"></param>
        /// <param name="chanel"></param>
        /// <param name="stimulsForm"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [DllImport("ELECTROSTIM.dll")]
        public static extern bool ElectroSetCommutatorChannelsStimuls(int hDevice, uint[] chanel, short[,] stimulsForm, UInt16 length);

        #endregion

        #region Методы

        /// <summary>
        /// Создает массив, описывающий форму стимула
        /// </summary>                
        void SetStimulationForm()
        {
            if (amplitudeStimulation > 0.100f)
            {
                amplitudeStimulation = 0.100f;
            }
            if (maximumAmplitude > 0.100f)
            {
                maximumAmplitude = 0.100f;
            }

            stimulFormArray = new short[MaxCurrentStimulPoints];
            uint NPoints;
            switch (stimulationForm)
            {
                case StimulationFormType.rectangle:
                                        
                    NPoints = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * RectangleDuration);
                    if (NPoints > MaxCurrentStimulPoints)
                    {
                        NPoints = MaxCurrentStimulPoints;
                    }
                    stimulFormArray = new short[NPoints];                    

                    for (int i = 0; i < NPoints; i++)
                    {
                        if (polarity != -1)
                        {
                            stimulFormArray[i] = Convert.ToInt16(amplitudeStimulation * CurrentToCode);
                        }
                        else
                        {
                            stimulFormArray[i] = Convert.ToInt16(-(amplitudeStimulation * CurrentToCode));
                        }
                    }
                    break;
                case StimulationFormType.trapezium:
                    //Передний фронт
                    uint N1 = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * T1);
                    //Полочка
                    uint N2 = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * T2);
                    //Задний фронт
                    uint N3 = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * T3);
                    while (N1 + N2 + N3 > MaxCurrentStimulPoints)
                    {
                        if (N1 > 0)
                        {
                            N1--;
                        }
                        if (N2 > 0)
                        {
                            N2--;
                        }
                        if (N3 > 0)
                        {
                            N3--;
                        }
                    }
                    stimulFormArray = new short[N1 + N2 + N3];
                    for (int i = 0; i < N1; i++)
                    {
                        if (polarity != -1)
                        {
                            stimulFormArray[i] = Convert.ToInt16(((amplitudeStimulation * CurrentToCode) / N1) * i);
                        }
                        else
                        {
                            stimulFormArray[i] = Convert.ToInt16(((-amplitudeStimulation * CurrentToCode) / N1) * i);
                        }
                    }
                    //Полочка                    
                    for (uint i = N1; i < N1 + N2; i++)
                    {
                        if (polarity != -1)
                        {
                            stimulFormArray[i] = Convert.ToInt16(amplitudeStimulation * CurrentToCode);
                        }
                        else
                        {
                            stimulFormArray[i] = Convert.ToInt16(-(amplitudeStimulation * CurrentToCode));
                        }
                    }
                    //Задний фронт                    
                    for (uint i = N1 + N2; i < N1 + N2 + N3; i++)
                    {
                        if (polarity != -1)
                        {
                            stimulFormArray[i] = Convert.ToInt16(((amplitudeStimulation * CurrentToCode) / N3) * (N3 + N2 + N1 - i));
                        }
                        else
                        {
                            stimulFormArray[i] = Convert.ToInt16(-((amplitudeStimulation * CurrentToCode) / N3) * (N3 + N2 + N1 - i));
                        }
                    }
                    break;
                case StimulationFormType.bipolarMeandr:
                    NPoints = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * BipolarMeandrDuration);
                    if (NPoints > MaxCurrentStimulPoints)
                    {
                        NPoints = MaxCurrentStimulPoints;
                    }
                    stimulFormArray = new short[NPoints];
                    for (int i = 0; i < stimulFormArray.Length; i++)
                    {
                        if (polarity != -1)
                        {
                            stimulFormArray[i] = Convert.ToInt16(((amplitudeStimulation / 2) * CurrentToCode) * System.Math.Sign(System.Math.Sin(2 * System.Math.PI * BipolarMeandrFrequency * i / MaxFrecKvantCurrentStimulator / timeCoefficient + 0.0001)));
                        }
                        else
                        {
                            stimulFormArray[i] = Convert.ToInt16(-(((amplitudeStimulation / 2) * CurrentToCode) * System.Math.Sign(System.Math.Sin(2 * System.Math.PI * BipolarMeandrFrequency * i / MaxFrecKvantCurrentStimulator / timeCoefficient + 0.0001))));
                        }
                    }
                    break;
                case StimulationFormType.unipolarMeandr:
                    //Число отсчетов в одном периоде несущей
                    uint DurT = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient / UnipolarMeandrFrequency);
                    NPoints = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * UnipolarMeandrDuration);
                    if (NPoints > MaxCurrentStimulPoints)
                    {
                        NPoints = MaxCurrentStimulPoints;
                    }
                    stimulFormArray = new short[NPoints];
                    if (DurT < 2)
                    {
                        DurT = 2;
                    }
                    //Число отсчетов в одном импульсе
                    uint DurN = DurT / UnipolarMeandrSkvagnost;
                    if (DurN < 1)
                    {
                        DurN = 1;
                    }
                    for (int i = 0; i < stimulFormArray.Length; i++)
                    {
                        if (i % DurT < DurN)
                        {
                            if (polarity != -1)
                            {
                                stimulFormArray[i] = Convert.ToInt16(amplitudeStimulation * CurrentToCode);
                            }
                            else
                            {
                                stimulFormArray[i] = Convert.ToInt16(-(amplitudeStimulation * CurrentToCode));
                            }
                        }
                    }
                    break;
                case StimulationFormType.sinusoid:
                    NPoints = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * SinusoidDuration);
                    if (NPoints > MaxCurrentStimulPoints)
                    {
                        NPoints = MaxCurrentStimulPoints;
                    }
                    stimulFormArray = new short[NPoints];
                    for (int i = 0; i < stimulFormArray.Length; i++)
                    {
                        if (polarity != -1)
                        {
                            stimulFormArray[i] = Convert.ToInt16(((amplitudeStimulation / 2) * CurrentToCode) * System.Math.Sin(2 * System.Math.PI * SinusoidFrequency * i / MaxFrecKvantCurrentStimulator / timeCoefficient));
                        }
                        else
                        {
                            stimulFormArray[i] = Convert.ToInt16(-(((amplitudeStimulation / 2) * CurrentToCode) * System.Math.Sin(2 * System.Math.PI * SinusoidFrequency * i / MaxFrecKvantCurrentStimulator / timeCoefficient)));
                        }
                    }
                    break;
                case StimulationFormType.modularSinusoid:
                    NPoints = Convert.ToUInt32(MaxFrecKvantCurrentStimulator / timeCoefficient * ModularSinusoidDuration);
                    if (NPoints > MaxCurrentStimulPoints)
                    {
                        NPoints = MaxCurrentStimulPoints;
                    }
                    stimulFormArray = new short[NPoints];
                    for (int i = 0; i < stimulFormArray.Length; i++)
                    {
                        if (polarity != -1)
                        {
                            double s1 = System.Math.Sin(2 * System.Math.PI * ModularSinusoidFrequency * i / MaxFrecKvantCurrentStimulator / timeCoefficient);
                            double s2 = System.Math.Sin(System.Math.PI / (MaxFrecKvantCurrentStimulator / timeCoefficient * ModularSinusoidDuration - 1) * i);
                            stimulFormArray[i] = Convert.ToInt16(((amplitudeStimulation / 2) * CurrentToCode) * s1 * s2);
                        }
                        else
                        {
                            double s1 = System.Math.Sin(2 * System.Math.PI * ModularSinusoidFrequency * i / MaxFrecKvantCurrentStimulator / timeCoefficient);
                            double s2 = System.Math.Sin(System.Math.PI / (MaxFrecKvantCurrentStimulator / timeCoefficient * ModularSinusoidDuration - 1) * i);
                            stimulFormArray[i] = Convert.ToInt16(-((amplitudeStimulation / 2) * CurrentToCode) * s1 * s2);
                        }
                    }
                    break;                
            }            
        }

        /// <summary>
        /// Открывает устройство
        /// </summary>
        public void OpenStimulator()
        {
            if (!isOpen)
            {
                isOpen = true;
                handle = OpenNSoftDevNikDrv(0x8300, 1);
                ElectroPowerOn(handle);
            }            
        }

        /// <summary>
        /// Закрывает устройство
        /// </summary>
        public void CloseStimulator()
        {
            if (isOpen)
            {
                isOpen = false;
                ElectroPowerOff(handle);
                CloseDev(handle);
            }            
        }

        /// <summary>
        /// Запускает стимуляцию
        /// </summary>
        public void StartStimulation()
        {            
            ElectroNumberOfStim(handle, countStimulations);
            ElectroSetPeriod(handle, periodStimulation);
            SetStimulationForm();
            //Задаем форму стимула  
            if (handle > 0)
            {
                IntPtr stimFormPtr = Marshal.AllocHGlobal(stimulFormArray.Length * sizeof(short));
                Marshal.Copy(stimulFormArray, 0, stimFormPtr, stimulFormArray.Length);
                lock (lockObject)
                {
                    ElectroSetStimul(handle, stimFormPtr, (ushort)stimulFormArray.Length);
                }
            }
            ElectroSetStart(handle, frame);            
        }

        /// <summary>
        /// Останавливает стимуляцию
        /// </summary>
        public void StopStimulation()
        {            
            ElectroStop(handle);
        }

        /// <summary>
        /// Задаются параметры стимуляций
        /// </summary>
        public void SetStimulationParameters(string periodStimulation, string durationStimulation, string countStimulations, 
                                                string amplitudeStimulation, string polarity, string stimulationForm, string amplitudeStep)
        {
            double num;
            if (double.TryParse(periodStimulation, out num))
            {
                PeriodStimulation = num;
            }

            float num1;
            if (float.TryParse(durationStimulation, out num1))
            {
                DurationStimulation = num1;
            }

            ushort num2;
            if (ushort.TryParse(countStimulations, out num2))
            {
                this.countStimulations = num2;
            }

            float num3;
            if (float.TryParse(amplitudeStimulation, out num3))
            {
                AmplitudeStimulation = num3;                
            }

            int num4;
            if (int.TryParse(polarity, out num4))
            {
                Polarity = num4;
            }

            float num5;
            if (float.TryParse(amplitudeStep, out num5))
            {
                AmplitudeStep = num5;
            }

            switch (stimulationForm)
            {
                case "прямоугольная":
                    this.stimulationForm = StimulationFormType.rectangle;
                    break;
                case "трапецевидная":
                    this.stimulationForm = StimulationFormType.trapezium;
                    break;
                case "однополярный меандр":
                    this.stimulationForm = StimulationFormType.unipolarMeandr;
                    break;
                case "двухполярный меандр":
                    this.stimulationForm = StimulationFormType.bipolarMeandr;
                    break;
                case "синусоидальная":
                    this.stimulationForm = StimulationFormType.sinusoid;
                    break;
                case "модулированная синусодальная":
                    this.stimulationForm = StimulationFormType.modularSinusoid;
                    break;
                default:
                    this.stimulationForm = StimulationFormType.rectangle;
                    break;
            }
        }

        /// <summary>
        /// Изменяется уровень стимуляции
        /// </summary>
        public void ChangeLevelStimulation(int correlation_command)
        {
            StopStimulation();
            if (correlation_command == 1)
            {
                LevelStimulation--;
                if (LevelStimulation > 0)
                {
                    AmplitudeStimulation -= AmplitudeStep;
                    StartStimulation();
                }
            }
            else if (correlation_command == 2)
            {
                LevelStimulation--;
                if (LevelStimulation > 0)
                {
                    AmplitudeStimulation -= AmplitudeStep;
                    StartStimulation();
                }
            }
            else if (correlation_command == 3)
            {
                LevelStimulation++;
                if (LevelStimulation == 1)
                {
                    StartStimulation();
                }
                else if (LevelStimulation > 1)
                {
                    AmplitudeStimulation += AmplitudeStep;
                    StartStimulation();
                }
            }
        }
        
        #endregion
    }
}
