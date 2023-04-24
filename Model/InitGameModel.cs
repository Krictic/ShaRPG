using ShaRPG.Controller.States;
using System.Collections;

namespace ShaRPG.Model
{
    internal class InitGameModel
    {

        public InitGameModel()
        {
            Stack<State> state = new Stack<State>();
            ArrayList CharList = new ArrayList();
            SetStates(state);
            SetCharacterList(CharList);
        }

        // Member Variables
        private bool end { get; set; }
        private Stack<State> states { get; set; }
        private ArrayList characterList { get; set; }

        public bool GetEnd()
        { return end; }
        public void SetEnd(bool value)
        { end = value; }

        public Stack<State> GetStates()
        { return states; }
        public void SetStates(Stack<State> states)
        { this.states = states; }

        public ArrayList GetCharacterList()
        { return characterList; }
        public void SetCharacterList(ArrayList characterList)
        { this.characterList = characterList; }
    }
}