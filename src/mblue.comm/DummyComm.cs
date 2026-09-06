// Copyright 2026 Robert Adams
// This Source Code Form is subject to the terms of the Mozilla Public
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using org.herbal3d.mblue.Logging;
using org.herbal3d.mblue.Statistics;

namespace org.herbal3d.mblue.comm {
    public class DummyComm : ICommProvider {
        private readonly MBLogger<DummyComm> _log;
        public string Name => "DummyComm";

        public bool IsConnected => false;

        public bool IsLoggedIn => false;

        public StatisticCollection CommStatistics => throw new NotImplementedException();

        public DummyComm(MBLogger<DummyComm> pLog) {
            _log = pLog;
            _log.LogInfo("Constructing DummyComm...");
        }

        public Task StartAsync(CancellationToken cancellationToken) {
            _log.LogInfo("StartAsync DummyComm...");
            return Task.CompletedTask;
        }

        public Task<LoginResponse?> StartLogin(LoginParams parms) {
            _log.LogInfo("StartLogin DummyComm...");
            return Task.FromResult<LoginResponse?>(null);
        }

        public bool StartLogout() {
            _log.LogInfo("StartLogout DummyComm...");
            return false;
        }

        public bool StartTeleport(string destination) {
            _log.LogInfo($"StartTeleport DummyComm to {destination}...");
            return false;
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            _log.LogInfo("StopAsync DummyComm...");
            return Task.CompletedTask;
        }
    }
}
