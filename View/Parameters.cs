using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class Parameters
    {
        public List<IParametersObserver> parametersObservers;

        public Parameters()
        {
            parametersObservers = new List<IParametersObserver>();
        }

        public void NotifyObserversThatParametersConfigured()
        {
            foreach (IParametersObserver observer in parametersObservers)
            {
                observer.ParametersConfigured();
            }
        }

    public void SubscribeToParametersConfigured(IParametersObserver observer)
    {
        parametersObservers.Add(observer);
    }
    public void UnsubscribeToParametersConfigured(IParametersObserver observer)
    {
        parametersObservers.Remove(observer);
    }
        public int nbOfCooks { get; set; }

        public int nbOfCommis { get; set; }

        public int nbOfDishwasher { get; set; }

        public int nbOfHeadWaiter { get; set; }

        public int nbOfWaiter { get; set; }

        public int scenarioId { get; set; }

        public int fFWDCoefficient { get; set; }

        public int cookCoef { get; set; }

        public int commisChefCoef { get; set; }

        public int dishwasherCoef { get; set; }

        public int headWaiterCoef { get; set; }

        public int waiterCoef { get; set; }

        public int butlerCoef { get; set; }

        public int headChefCoef { get; set; }

        public int commisSalleCoef { get; set; }


    }
}
