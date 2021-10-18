using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public class StateHandlerAttribute : Attribute {

        private readonly BotState _state;

        public StateHandlerAttribute(BotState state) {
            _state = state;
        }

        public BotState State {
            get {
                return _state;
            }
        }

    }
}
